using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using UriStore.Application.Features.Order.Queries.GetOrder;
using UriStore.Application.Features.Order.Queries.GetOrders;
using UriStore.Application.Features.Order.Queries.GetOrdersByUserId;
using UriStore.Application.Interfaces;

namespace UriStore.Presentation.Endpoints.V1.Orders
{
    public class OrdersCarterV1() : ICarterModule
    {
        private const string BaseUrl = "api/v{version:apiVersion}/orders";

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("order-carter-name-show-on-swagger")
                .MapGroup(BaseUrl)
                .HasApiVersion(1);

            group1.MapGet(string.Empty, GetAll);
            group1.MapGet("{id}", Get);
            group1.MapGet("user", GetAllByUserId);
        }

        public async Task<IResult> GetAll(ISender sender, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            return Results.Ok(await sender.Send(new GetOrdersQuery { PageNumber = pageNumber, PageSize = pageSize }));
        }

        public async Task<IResult> Get(ISender sender, long id)
        {
            return Results.Ok(await sender.Send(new GetOrderQuery { Id = id }));
        }

        public async Task<IResult> GetAllByUserId(ISender sender, [FromQuery] Guid userId, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            return Results.Ok(await sender.Send(new GetOrdersByUserIdQuery { PageNumber = pageNumber, PageSize = pageSize, UserId = userId }));
        }
    }
}