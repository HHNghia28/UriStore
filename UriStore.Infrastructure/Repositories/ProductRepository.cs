﻿using Dapper;
using MediatR;
using UriStore.Application.DTO;
using UriStore.Application.Interfaces;
using UriStore.Application.Wrappers;
using UriStore.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Infrastructure.Repositories
{
    public class ProductRepository(ApplicationDbContext context, ISqlConnectionFactory _sqlConnectionFactory) 
        : Repository<Domain.Entities.Product>(context), IProductRepository
    {
        public async Task<ProductResponse> GetProduct(Guid id)
        {
            using var connect = _sqlConnectionFactory.GetOpenConnection();
            const string sqlProduct = @"
                    SELECT
                        ""Products"".""Id"",
                        ""Products"".""Name"",
                        ""Products"".""Description"",
                        ""Products"".""Price"",
                        ""Products"".""Discount"",
                        ""Products"".""Stock"",
                        ""Products"".""Photo"",
                        ""Products"".""IsDeleted"",
                        ""Products"".""CreatedById"",
                        ""Products"".""LastModifiedById"",
                        ""Products"".""CreatedAt"",
                        ""Products"".""LastModifiedAt"",
                        ""Products"".""CategoryId"",
                        ""Categories"".""Name"" as ""Category""
                    FROM ""Products""
                    INNER JOIN ""Categories"" ON ""Products"".""CategoryId"" = ""Categories"".""Id""
                    WHERE ""Products"".""Id"" = @Id
                "
            ;

            var product = await connect.QueryFirstOrDefaultAsync<ProductResponse>(sqlProduct, new { Id = id });

            return product;
        }

        public async Task<PagedResponse<List<ProductsResponse>>> GetProducts(PagedRequest request)
        {
            using var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sqlProducts = @"
                    SELECT 
                        ""Products"".""Id"",
                        ""Products"".""Name"",
                        ""Products"".""Price"",
                        ""Products"".""Discount"",
                        ""Products"".""Stock"",
                        ""Products"".""Photo"",
                        ""Products"".""LastModifiedAt"",
                        ""Products"".""CategoryId"",
                        ""Categories"".""Name"" AS ""Category""
                    FROM ""Products""
                    INNER JOIN ""Categories"" ON ""Products"".""CategoryId"" = ""Categories"".""Id""
                    WHERE ""Products"".""IsDeleted"" = false
                    ORDER BY ""Products"".""LastModifiedAt"" DESC
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var offset = (request.PageNumber - 1) * request.PageSize;
            var products = await connection.QueryAsync<ProductsResponse>(sqlProducts, new { Offset = offset, PageSize = request.PageSize });

            const string sqlCount = @"
                    SELECT COUNT(*)
                    FROM ""Products""
                    INNER JOIN ""Categories"" ON ""Products"".""CategoryId"" = ""Categories"".""Id""";

            var totalRecords = await connection.ExecuteScalarAsync<int>(sqlCount);

            var response = new PagedResponse<List<ProductsResponse>>(
                products.AsList(),
                request.PageNumber,
                request.PageSize,
                totalRecords,
                (int)Math.Ceiling((double)totalRecords / request.PageSize)
            );

            return response;
        }
    }
}
