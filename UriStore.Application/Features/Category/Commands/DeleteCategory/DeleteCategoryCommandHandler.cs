﻿using MediatR;
using UriStore.Application.Exceptions;
using UriStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler(ICategoryRepository _categoryRepository) : IRequestHandler<DeleteCategoryCommand>
    {
        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Category not found");

            category.LastModifiedById = request.UserId;
            category.IsDeleted = true;

            await _categoryRepository.UpdateAsync(category);
            await _categoryRepository.SaveAsync();
        }
    }
}
