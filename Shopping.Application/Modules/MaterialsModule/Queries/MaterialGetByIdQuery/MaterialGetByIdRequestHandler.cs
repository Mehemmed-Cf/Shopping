using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.MaterialsModule.Queries.MaterialGetByIdQuery
{
    class MaterialGetByIdRequestHandler : IRequestHandler<MaterialGetByIdRequest, MaterialRequestDto>
    {
        private readonly IMaterialRepository materialRepository;

        public MaterialGetByIdRequestHandler(IMaterialRepository materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public async Task<MaterialRequestDto> Handle(MaterialGetByIdRequest request, CancellationToken cancellationToken)
        {
            Material entity;

            if (request.OnlyAvailable)
            {
                entity = await materialRepository.GetAsync(m => m.Id == request.Id && m.DeletedBy == null, cancellationToken);
            }
            else
            {
                entity = await materialRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            }

            var dto = new MaterialRequestDto
            {
                Id = entity.Id,
                Name = entity.Name,
            };

            return dto;
        }
    }
}
