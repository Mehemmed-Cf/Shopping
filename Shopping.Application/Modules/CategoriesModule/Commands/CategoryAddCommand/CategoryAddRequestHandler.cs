using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.CategoriesModule.Commands.CategoryAddCommand
{
    class CategoryAddRequestHandler : IRequestHandler<CategoryAddRequest>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryAddRequestHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task Handle(CategoryAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new Category
            {
                Name = request.Name,
                Type = request.Type
            };

            if (request.ParentId is not null)
            {
                var parent = await categoryRepository.GetAsync(m => m.Id == request.ParentId, cancellationToken);

                entity.ParentId = parent.Id;
            }

            await categoryRepository.AddAsync(entity);
            await categoryRepository.SaveAsync(cancellationToken);
        }
    }
}
