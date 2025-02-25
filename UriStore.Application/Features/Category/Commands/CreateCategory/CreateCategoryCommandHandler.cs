﻿using MediatR;
using UriStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler(ICategoryRepository _categoryRepository) : IRequestHandler<CreateCategoryCommand>
    {
        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.AddAsync(new Domain.Entities.Category
            {
                Name = request.Name,
                CreatedById = request.CreatedById,
                LastModifiedById = request.CreatedById,
            });

            await _categoryRepository.SaveAsync();
        }
    }
}
