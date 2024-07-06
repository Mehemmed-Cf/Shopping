using MediatR;
using Shopping.Application.Modules.MaterialsModule.Commands.MaterialAddCommand;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.MaterialsModule.Commands.MaterailAddCommand
{
    class MaterialAddRequestHandler : IRequestHandler<MaterialAddRequest, Material>
    {
        private readonly IMaterialRepository materialRepository;

        public MaterialAddRequestHandler(IMaterialRepository materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public async Task<Material> Handle(MaterialAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new Material
            {
                Name = request.Name,
            };

            await materialRepository.AddAsync(entity, cancellationToken);
            await materialRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
