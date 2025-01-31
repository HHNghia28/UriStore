using MediatR;
using UriStore.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Category.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<List<CategoryResponse>>
    {
    }
}
