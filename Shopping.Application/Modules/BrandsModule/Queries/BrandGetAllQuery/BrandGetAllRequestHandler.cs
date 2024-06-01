using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Modules.MaterialsModule.Queries;
using Shopping.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.BrandsModule.Queries.BrandGetAllQuery
{
    class BrandGetAllRequestHandler : IRequestHandler<BrandGetAllRequest, IEnumerable<BrandRequestDto>>
    {
        private readonly IBrandRepository brandRepository;

        public BrandGetAllRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task<IEnumerable<BrandRequestDto>> Handle(BrandGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = brandRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }

            var response = await query.Select(m => new BrandRequestDto
            {
                Id = m.Id,
                Name = m.Name,
            }).ToListAsync(cancellationToken);

            return response;
        }
    }
}
