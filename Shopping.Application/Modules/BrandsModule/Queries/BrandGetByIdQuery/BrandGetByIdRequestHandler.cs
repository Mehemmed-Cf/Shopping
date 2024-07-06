using MediatR;
using Shopping.Application.Modules.MaterialsModule.Queries;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.BrandsModule.Queries.BrandGetByIdQuery
{
    class BrandGetByIdRequestHandler : IRequestHandler<BrandGetByIdRequest, BrandRequestDto>
    {
        private readonly IBrandRepository brandRepository;

        public BrandGetByIdRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task<BrandRequestDto> Handle(BrandGetByIdRequest request, CancellationToken cancellationToken)
        {
            Brand entity;

            if (request.OnlyAvailable)
            {
                entity = await brandRepository.GetAsync(m => m.Id == request.Id && m.DeletedBy == null, cancellationToken);
            }
            else
            {
                entity = await brandRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            }

            var dto = new BrandRequestDto
            {
                Id = entity.Id,
                Name = entity.Name,
            };

            return dto;
        }
    }
}
