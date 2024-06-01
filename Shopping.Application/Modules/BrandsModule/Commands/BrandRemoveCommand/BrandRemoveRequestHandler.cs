using MediatR;
using Shopping.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.BrandsModule.Commands.BrandRemoveCommand
{
    class BrandRemoveRequestHandler : IRequestHandler<BrandRemoveRequest>
    {
        private readonly IBrandRepository brandRepository;

        public BrandRemoveRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task Handle(BrandRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity = await brandRepository.GetAsync(m => m.Id == request.Id && m.DeletedBy == null, cancellationToken);

            brandRepository.Remove(entity);
            await brandRepository.SaveAsync(cancellationToken);
        }
    }
}
