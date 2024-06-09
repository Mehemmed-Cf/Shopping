using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Modules.ColorsModule.Queries;
using Shopping.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.MaterialsModule.Queries.MaterialGetAllQuery
{
    class MaterialGetAllRequestHandler : IRequestHandler<MaterialGetAllRequest, IEnumerable<MaterialRequestDto>>
    {
        private readonly IMaterialRepository materialRepository;

        public MaterialGetAllRequestHandler(IMaterialRepository materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public async Task<IEnumerable<MaterialRequestDto>> Handle(MaterialGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = materialRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }

            var response = await query.Select(m => new MaterialRequestDto
            {
                Id = m.Id,
                Name = m.Name,
            }).ToListAsync(cancellationToken);

            return response;
        }
    }
}
