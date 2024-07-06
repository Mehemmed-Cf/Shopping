using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.SizesModule.Queries.SizeGetByIdQuery
{
    class SizeGetByIdRequestHandler : IRequestHandler<SizeGetByIdRequest, SizeRequestDto>
    {
        private readonly ISizeRepository sizeRepository;

        public SizeGetByIdRequestHandler(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }

        public async Task<SizeRequestDto> Handle(SizeGetByIdRequest request, CancellationToken cancellationToken)
        {
            Size entity;

            if(request.OnlyAvailable)
            {
                entity = await sizeRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);
            } else
            {
                entity = await sizeRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            }

            var dto = new SizeRequestDto
            {
                Id = entity.Id,
                Name = entity.Name,
                SmallName = entity.SmallName,
            };

            return dto;
        }
    }
}
