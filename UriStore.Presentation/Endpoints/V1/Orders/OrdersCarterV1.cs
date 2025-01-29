﻿using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using UriStore.Application.Features.Order.Commands.CancelOrder;
using UriStore.Application.Features.Order.Commands.CreateOrder;
using UriStore.Application.Features.Order.Commands.UpdateOrder;
using UriStore.Application.Features.Order.Queries.GetOrder;
using UriStore.Application.Features.Order.Queries.GetOrders;
using UriStore.Application.Features.Order.Queries.GetOrdersByUserId;
using UriStore.Application.Features.Payment.Commands.CreatePaymentOrder;

namespace Order.Presentation.Endpoints.V1.Orders
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
            group1.MapPost(string.Empty, Create);
            group1.MapPut("{id}", Update);
            group1.MapDelete("cancel/{id}", Cancel);
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

        public async Task<IResult> Create(ISender sender, [FromHeader(Name = "X-User-Id")] Guid userId, [FromBody] CreateOrderCommand request)
        {
            request.CreatedBy = userId;
            long id = await sender.Send(request);
            return Results.Ok(id);
        }

        public async Task<IResult> Update(ISender sender, long id, [FromHeader(Name = "X-User-Id")] Guid userId, [FromBody] UpdateOrderCommand request)
        {
            request.Id = id;
            request.LastModifiedBy = userId;
            await sender.Send(request);
            return Results.Ok("Update order successful");
        }

        public async Task<IResult> Cancel(ISender sender, long id, [FromHeader(Name = "X-User-Id")] Guid userId)
        {
            await sender.Send(new CancelOrderCommand { Id = id, LastModifiedBy = userId });
            return Results.Ok("Cancel order successful");
        }
    }
}