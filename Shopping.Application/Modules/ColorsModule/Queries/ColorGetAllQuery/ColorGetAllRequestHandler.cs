using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.ColorsModule.Queries.ColorGetAllQuery
{
    internal class ColorGetAllRequestHandler : IRequestHandler<ColorGetAllRequest, IEnumerable<ColorRequestDto>>
    {
        private readonly IColorRepository colorRepository;

        public ColorGetAllRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }

        public async Task<IEnumerable<ColorRequestDto>> Handle(ColorGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = colorRepository.GetAll();

            if(request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }

            var response = await query.Select(m => new ColorRequestDto
            {
                Id = m.Id,
                Name = m.Name,
                HexCode = m.HexCode,
            }).ToListAsync(cancellationToken);

            return response;
        }
    }
}
