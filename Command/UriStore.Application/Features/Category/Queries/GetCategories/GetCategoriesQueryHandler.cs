using Dapper;
using MediatR;
using UriStore.Application.DTO;
using UriStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Category.Queries.GetCategories
{
    public class GetCategoriesQueryHandler(ICategoryRepository _categoryRepository) : IRequestHandler<GetCategoriesQuery, List<CategoryResponse>>
    {
        public async Task<List<CategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetCategories();
        }
    }
}
