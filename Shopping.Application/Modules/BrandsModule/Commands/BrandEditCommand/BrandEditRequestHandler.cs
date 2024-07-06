using MediatR;
using Shopping.Application.Modules.MaterialsModule.Commands.MaterialEditCommand;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.BrandsModule.Commands.BrandEditCommand
{
    class BrandEditRequestHandler : IRequestHandler<BrandEditRequest, Brand>
    {
        private readonly IBrandRepository brandRepository;

        public BrandEditRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task<Brand> Handle(BrandEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await brandRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            entity.Name = request.Name;

            await brandRepository.EditAsync(entity);
            await brandRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
