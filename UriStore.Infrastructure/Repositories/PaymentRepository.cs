using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Application.DTO;
using UriStore.Application.Interfaces;
using UriStore.Application.Wrappers;
using UriStore.Domain.Entities;
using UriStore.Infrastructure.Context;

namespace UriStore.Infrastructure.Repositories
{
    public class PaymentRepository(ApplicationDbContext context, ISqlConnectionFactory sqlConnectionFactory) 
        : Repository<Payment>(context), IPaymentRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Payment>> GetExpiredsPayments()
        {
            return await _context.Payments.Where(p => p.Status == Domain.Enums.PaymentStatus.PENDING
                && p.LastModifiedAt.HasValue && p.LastModifiedAt.Value.AddMinutes(5) < DateTime.UtcNow)
                .ToListAsync();
        }

        public async Task<PagedResponse<List<PaymentResponse>>> GetPayments(PagedRequest request)
        {
            using var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sqlPayments = @"
                    SELECT 
                        ""Payments"".""Id"",
                        ""Payments"".""AmountCharged"",
                        ""Payments"".""TimeCharge"",
                        ""Payments"".""Status"",
                        ""Users"".""Id"" AS ""UserId"",
                        ""Users"".""Email"" AS ""Email"",
                        ""Users"".""FullName"" AS ""FullName""
                    FROM ""Payments""
                    INNER JOIN ""Payments"" ON ""Payments"".""CreatedById"" = ""Users"".""Id""
                    ORDER BY ""Payments"".""LastModifiedAt"" DESC
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var offset = (request.PageNumber - 1) * request.PageSize;
            var products = await connection.QueryAsync<PaymentResponse>(sqlPayments, new { Offset = offset, PageSize = request.PageSize });

            const string sqlCount = @"
                    SELECT COUNT(*)
                    FROM ""Products""
                    INNER JOIN ""Categories"" ON ""Products"".""CategoryId"" = ""Categories"".""Id""";

            var totalRecords = await connection.ExecuteScalarAsync<int>(sqlCount);

            var response = new PagedResponse<List<PaymentResponse>>(
                products.AsList(),
                request.PageNumber,
                request.PageSize,
                (int)Math.Ceiling((double)totalRecords / request.PageSize)
            );

            return response;
        }
    }
}
