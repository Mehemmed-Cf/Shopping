using MediatR;
using Shopping.Application.Repositories;
using Shopping.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.CategoriesModule.Commands.CategoryEditCommand
{
    class CategoryEditRequestHandler : IRequestHandler<CategoryEditRequest>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryEditRequestHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task Handle(CategoryEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await categoryRepository.GetAsync(m => m.Id == request.Id, cancellationToken);

            if (request.Id == request.ParentId)
            {
                throw new CircleReferenceException("ParentId");
            }
            else if (request.ParentId is not null)
            {
/*                var relatedIds = (await categoryRepository.GetRelatedIds(entity.Id)).Select(m => m.Id);

                if (relatedIds.Contains(request.ParentId.Value))
                    throw new BadRequestException("Circle Reference Exception");*/

                var relatedIds = await categoryRepository.GetRelatedIds(entity.Id);

                if (relatedIds.Any(m => m.Id == request.ParentId.Value))
                    throw new CircleReferenceException("ParentId");
            }

            entity.Name = request.Name;
            entity.Type = request.Type;
            entity.ParentId = request.ParentId;
            await categoryRepository.SaveAsync();
        }
    }
}
