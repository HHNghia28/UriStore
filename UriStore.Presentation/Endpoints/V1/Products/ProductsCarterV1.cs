﻿using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UriStore.Application.Exceptions;
using UriStore.Application.Features.Product.Commands.CreateProduct;
using UriStore.Application.Features.Product.Commands.DeleteProduct;
using UriStore.Application.Features.Product.Commands.UpdateProduct;
using UriStore.Application.Features.Product.Queries.GetProduct;
using UriStore.Application.Features.Product.Queries.GetProducts;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace UriStore.Presentation.Endpoints.V1.Products
{
    public class ProductsCarterV1 : ICarterModule
    {
        private const string BaseUrl = "api/v{version:apiVersion}/products";

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("product-carter-name-show-on-swagger")
                .MapGroup(BaseUrl)
                .HasApiVersion(1);

            group1.MapGet(string.Empty, GetAll);
            group1.MapGet("{id}", Get);
            group1.MapPost(string.Empty, Create).RequireAuthorization("AdminPolicy");
            group1.MapPut("{id}", Update).RequireAuthorization("AdminPolicy");
            group1.MapDelete("{id}", Delete).RequireAuthorization("AdminPolicy");
        }

        public async Task<IResult> GetAll(ISender sender, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            return Results.Ok(await sender.Send(new GetProductsQuery { PageNumber = pageNumber, PageSize = pageSize }));
        }

        public async Task<IResult> Get(ISender sender, Guid id)
        {
            var product = await sender.Send(new GetProductQuery() { Id = id, });

            if (product == null) return Results.NotFound("Product not found");

            return Results.Ok(product);
        }

        public async Task<IResult> Create(ISender sender, [FromHeader(Name = "X-User-Id")] Guid userId, [FromBody] CreateProductCommand request)
        {
            request.CreatedById = userId;
            await sender.Send(request);
            return Results.Ok("Create product successful");
        }

        public async Task<IResult> Update(ISender sender, Guid id, [FromHeader(Name = "X-User-Id")] Guid userId, [FromBody] UpdateProductCommand request)
        {
            request.Id = id;
            request.LastModifiedById = userId;
            await sender.Send(request);
            return Results.Ok("Update product successful");
        }

        public async Task<IResult> Delete(ISender sender, Guid id, [FromHeader(Name = "X-User-Id")] Guid userId)
        {
            await sender.Send(new DeleteProductCommand { Id = id, LastModifiedById = userId});
            return Results.Ok("Delete product successful");
        }
    }
}
