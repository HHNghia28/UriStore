using UriStore.Domain.Entities;
using UriStore.Application.Interfaces;
using UriStore.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Application.DTO;
using Dapper;

namespace UriStore.Infrastructure.Repositories
{
    public class CategoryRepository(ApplicationDbContext _context, ISqlConnectionFactory _sqlConnectionFactory) 
        : Repository<Category>(_context), ICategoryRepository
    {
        public async Task<List<CategoryResponse>> GetCategories()
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            const string categoriesQuery = @"
                    SELECT
                        ""Categories"".""Id"",
                        ""Categories"".""Name""
                    FROM ""Categories""
                    WHERE ""Categories"".""IsDeleted"" = false
                ";

            var categories = await connection.QueryAsync<CategoryResponse>(categoriesQuery);
            return categories.AsList();
        }
    }
}
