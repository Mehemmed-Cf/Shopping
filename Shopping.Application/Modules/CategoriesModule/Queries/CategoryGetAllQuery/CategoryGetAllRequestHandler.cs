using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.CategoriesModule.Queries.CategoryGetAllQuery
{
    class CategoryGetAllRequestHandler : IRequestHandler<CategoryGetAllRequest, IEnumerable<CategoryRequestDto>>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryGetAllRequestHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryRequestDto>> Handle(CategoryGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = categoryRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(c => c.DeletedBy == null);
            }

            var response = await query.Select(c => new CategoryRequestDto
            {
                Id = c.Id,
                Name = c.Name,
                ParentId = c.ParentId,
                Type = c.Type,
            }).ToListAsync(cancellationToken);

            return response;

            //return await categoryRepository.GetAll(m => m.DeletedAt == null).ToListAsync(cancellationToken);
        }
    }
}
