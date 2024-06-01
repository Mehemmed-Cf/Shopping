using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.SizesModule.Commands.SizeAddCommand
{
    class SizeAddRequestHandler : IRequestHandler<SizeAddRequest, Size>
    {
        private readonly ISizeRepository sizeRepository;

        public SizeAddRequestHandler(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }

        public async Task<Size> Handle(SizeAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new Size
            {
                Name = request.Name,
                SmallName = request.SmallName,
            };

            await sizeRepository.AddAsync(entity, cancellationToken);
            await sizeRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
