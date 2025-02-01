using UriStore.Application.DTO;
using UriStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<CategoryResponse>> GetCategories();
    }
}
