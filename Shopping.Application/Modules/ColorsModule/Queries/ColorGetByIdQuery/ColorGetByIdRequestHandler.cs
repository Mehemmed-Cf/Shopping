using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.ColorsModule.Queries.ColorGetByIdQuery
{
     class ColorGetByIdRequestHandler : IRequestHandler<ColorGetByIdRequest, ColorRequestDto>
    {
        private readonly IColorRepository ColorRepository;

        public ColorGetByIdRequestHandler(IColorRepository ColorRepository)
        {
            this.ColorRepository = ColorRepository;
        }

        public async Task<ColorRequestDto> Handle(ColorGetByIdRequest request, CancellationToken cancellationToken)
        {
            Color entity;

            if (request.OnlyAvailable)
            {
                entity = await ColorRepository.GetAsync(m => m.Id == request.Id && m.DeletedBy == null, cancellationToken);
            }
            else
            {
                entity = await ColorRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            }

            var dto = new ColorRequestDto
            {
                Id = entity.Id,
                Name = entity.Name,
                HexCode = entity.HexCode,
            };

            return dto;
        }
    }
}
