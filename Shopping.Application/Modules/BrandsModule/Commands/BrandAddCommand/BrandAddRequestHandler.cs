using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.BrandsModule.Commands.BrandAddCommand
{
    class BrandAddRequestHandler : IRequestHandler<BrandAddRequest, Brand>
    {
        private readonly IBrandRepository brandRepository;

        public BrandAddRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task<Brand> Handle(BrandAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new Brand
            {
                Name = request.Name,
            };

            await brandRepository.AddAsync(entity, cancellationToken);
            await brandRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
