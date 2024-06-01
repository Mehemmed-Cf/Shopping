using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.SizesModule.Commands.SizeEditCommand
{
    class SizeEditRequestHandler : IRequestHandler<SizeEditRequest, Size>
    {
        private readonly ISizeRepository sizeRepository;

        public SizeEditRequestHandler(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }

        public async Task<Size> Handle(SizeEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await sizeRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            entity.Name = request.Name;
            entity.SmallName = request.SmallName;

            await sizeRepository.EditAsync(entity);
            await sizeRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
