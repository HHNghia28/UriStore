﻿using Dapper;
using MediatR;
using UriStore.Application.DTO;
using UriStore.Application.Exceptions;
using UriStore.Application.Interfaces;
using UriStore.Application.Wrappers;
using UriStore.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UriStore.Infrastructure.Repositories
{
    public class OrderRepository(ApplicationDbContext context, ISqlConnectionFactory sqlConnectionFactory) 
        : Repository<Domain.Entities.Order>(context), IOrderRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;

        public async Task<long> GetLastId()
        {
            using var connection = _sqlConnectionFactory.GetOpenConnection();

            var currentDate = DateTime.UtcNow.Date;

            const string sqlOrders = @"
                SELECT ""Id""
                FROM ""Orders""
                WHERE ""CreatedAt"" >= @CurrentDate
                ORDER BY ""Id"" DESC
                LIMIT 1";

            var orderId = await connection.QuerySingleOrDefaultAsync<long?>(sqlOrders, new { CurrentDate = currentDate });

            return orderId ?? long.Parse(currentDate.ToString("yyyyMMdd") + "000000");
        }

        public async Task<OrderResponse> GetOrder(long id)
        {
            using var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sqlOrder = @"
                    SELECT
                        ""Orders"".""Id"",
                        ""Orders"".""FullName"",
                        ""Orders"".""Phone"",
                        ""Orders"".""Address"",
                        ""Orders"".""Note"",
                        ""Orders"".""ShippingFee"",
                        ""Orders"".""DiscountFee"",
                        ""Orders"".""VoucherName"",
                        ""Orders"".""VoucherCode"",
                        ""Orders"".""VoucherValue"",
                        ""Orders"".""TotalPrice"",
                        ""Orders"".""Status"",
                        ""Orders"".""CreatedById"",
                        ""Orders"".""CreatedAt"",
                        ""Orders"".""LastModifiedById"",
                        ""Orders"".""LastModifiedAt""
                    FROM ""Orders""
                    WHERE ""Orders"".""Id"" = @Id
                "
            ;

            var order = await connection.QueryFirstOrDefaultAsync<OrderResponse>(sqlOrder, new { Id = id }) ?? throw new NotFoundException("Order not found");

            const string sqlOrderDetail = @"
                    SELECT 
                        ""OrderDetails"".""Id"",
                        ""OrderDetails"".""Name"",
                        ""OrderDetails"".""Price"",
                        ""OrderDetails"".""Discount"",
                        ""OrderDetails"".""Quantity"",
                        ""OrderDetails"".""Photo"",
                        ""OrderDetails"".""Category"",
                        ""OrderDetails"".""ProductId""
                    FROM ""OrderDetails""
                    WHERE ""OrderDetails"".""OrderId"" = @OrderId
                "
            ;
            var orderDetails = await connection.QueryAsync<OrderDetailResponse>(sqlOrderDetail, new { OrderId = order.Id });

            order.Details = orderDetails.ToList();

            return order;
        }

        public async Task<PagedResponse<List<OrdersResponse>>> GetOrders(PagedRequest request)
        {
            using var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sqlOrders = @"
                    SELECT 
                        ""Orders"".""Id"",
                        ""Orders"".""FullName"",
                        ""Orders"".""Phone"",
                        ""Orders"".""Address"",
                        ""Orders"".""TotalPrice"",
                        ""Orders"".""Status"",
                        ""Orders"".""CreatedAt"",
                        ""Orders"".""LastModifiedAt""
                    FROM ""Orders""
                    ORDER BY ""Orders"".""LastModifiedAt"" DESC
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var offset = (request.PageNumber - 1) * request.PageSize;
            var Orders = await connection.QueryAsync<OrdersResponse>(sqlOrders, new { Offset = offset, PageSize = request.PageSize });

            const string sqlCount = @"
                    SELECT COUNT(*)
                    FROM ""Orders""";

            var totalRecords = await connection.ExecuteScalarAsync<int>(sqlCount);

            var response = new PagedResponse<List<OrdersResponse>>(
                Orders.AsList(),
                request.PageNumber,
                request.PageSize,
                (int)Math.Ceiling((double)totalRecords / request.PageSize)
            );

            return response;
        }

        public async Task<PagedResponse<List<OrdersResponse>>> GetOrdersByUserId(PagedRequest request, Guid userId)
        {
            using var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sqlOrders = @"
                    SELECT 
                        ""Orders"".""Id"",
                        ""Orders"".""FullName"",
                        ""Orders"".""Phone"",
                        ""Orders"".""Address"",
                        ""Orders"".""TotalPrice"",
                        ""Orders"".""Status"",
                        ""Orders"".""CreatedAt"",
                        ""Orders"".""LastModifiedAt""
                    FROM ""Orders""
                    WHERE ""Orders"".""CreatedById"" = @Id
                    ORDER BY ""Orders"".""LastModifiedAt"" DESC
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var offset = (request.PageNumber - 1) * request.PageSize;
            var Orders = await connection.QueryAsync<OrdersResponse>(sqlOrders, new { Offset = offset, PageSize = request.PageSize, Id = userId });

            const string sqlCount = @"
                    SELECT COUNT(*)
                    FROM ""Orders""";

            var totalRecords = await connection.ExecuteScalarAsync<int>(sqlCount);

            var response = new PagedResponse<List<OrdersResponse>>(
                Orders.AsList(),
                request.PageNumber,
                request.PageSize,
                (int)Math.Ceiling((double)totalRecords / request.PageSize)
            );

            return response;
        }
    }
}
