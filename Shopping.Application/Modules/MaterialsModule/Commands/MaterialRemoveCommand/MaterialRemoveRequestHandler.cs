using MediatR;
using Shopping.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.MaterialsModule.Commands.MaterialRemoveCommand
{
    class MaterialRemoveRequestHandler : IRequestHandler<MaterialRemoveRequest>
    {
        private readonly IMaterialRepository materialRepository;

        public MaterialRemoveRequestHandler(IMaterialRepository materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public async Task Handle(MaterialRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity = await materialRepository.GetAsync(m => m.Id == request.Id && m.DeletedBy == null, cancellationToken);

            materialRepository.Remove(entity);
            await materialRepository.SaveAsync(cancellationToken);
        }
    }
}
