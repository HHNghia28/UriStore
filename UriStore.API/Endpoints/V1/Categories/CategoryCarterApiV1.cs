﻿using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UriStore.Application.Features.Category.Commands.CreateCategory;
using UriStore.Application.Features.Category.Commands.DeleteCategory;
using UriStore.Application.Features.Category.Commands.UpdateCategory;
using UriStore.Application.Features.Category.Queries.GetCategories;

namespace UriStore.API.Endpoints.V1.Categories
{
    public class CategoryCarterApiV1 : ICarterModule
    {
        private const string BaseUrl = "api/v{version:apiVersion}/categories";

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("category-carter-name-show-on-swagger")
                .MapGroup(BaseUrl)
                .HasApiVersion(1);

            group1.MapGet(string.Empty, Get);
            group1.MapPost(string.Empty, Create).RequireAuthorization("AdminPolicy");
            group1.MapPut("{id}", Update).RequireAuthorization("AdminPolicy");
            group1.MapDelete("{id}", Delete).RequireAuthorization("AdminPolicy");
        }

        public async Task<IResult> Get(ISender sender)
        {
            var category = await sender.Send(new GetCategoriesQuery());

            if (category.Count <= 0)
            {
                return Results.NotFound();
            }

            return Results.Ok(category);
        }

        public async Task<IResult> Create(ISender sender, [FromHeader(Name = "X-User-Id")] Guid userId, [FromBody] CreateCategoryCommand command)
        {
            command.CreatedById = userId;
            await sender.Send(command);
            return Results.Ok("Create category successful");
        }

        public async Task<IResult> Update(ISender sender, int id, [FromHeader(Name = "X-User-Id")] Guid userId, [FromBody] UpdateCategoryCommand command)
        {
            command.Id = id;
            command.LastModifiedById = userId;
            await sender.Send(command);
            return Results.Ok("Update category successful");
        }

        public async Task<IResult> Delete(ISender sender, int id, [FromHeader(Name = "X-User-Id")] Guid userId)
        {
            await sender.Send(new DeleteCategoryCommand { Id = id, UserId = userId});
            return Results.Ok("Delete category successful");
        }
    }
}
