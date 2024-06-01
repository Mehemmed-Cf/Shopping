using MediatR;
using Shopping.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.SizesModule.Commands.SizeRemoveCommand
{
    class SizeRemoveRequestHandler : IRequestHandler<SizeRemoveRequest>
    {
        private readonly ISizeRepository sizeRepository;

        public SizeRemoveRequestHandler(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }

        public async Task Handle(SizeRemoveRequest request, CancellationToken cancellationToken)
        {
           var entity = await sizeRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            sizeRepository.Remove(entity);
            await sizeRepository.SaveAsync(cancellationToken);
        }
    }
}
