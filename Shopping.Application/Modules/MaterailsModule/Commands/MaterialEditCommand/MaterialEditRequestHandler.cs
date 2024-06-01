using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.MaterialsModule.Commands.MaterialEditCommand
{
    class MaterialEditRequestHandler : IRequestHandler<MaterialEditRequest, Material>
    {
        private readonly IMaterialRepository materialRepository;

        public MaterialEditRequestHandler(IMaterialRepository materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public async Task<Material> Handle(MaterialEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await materialRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            entity.Name = request.Name;

            await materialRepository.EditAsync(entity);
            await materialRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
