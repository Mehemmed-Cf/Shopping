using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.SizesModule.Queries.SizeGetAllQuery
{
    class SizeGetAllRequestHandler : IRequestHandler<SizeGetAllRequest, IEnumerable<SizeRequestDto>>
    {
        private readonly ISizeRepository sizeRepository;

        public SizeGetAllRequestHandler(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }

        public async Task<IEnumerable<SizeRequestDto>> Handle(SizeGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = sizeRepository.GetAll();

            if(request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }

            var response = await query.Select(m => new SizeRequestDto
            {
                Id = m.Id,
                Name = m.Name,
                SmallName = m.SmallName
            }).ToListAsync(cancellationToken);

            return response;

        }
    }
}
