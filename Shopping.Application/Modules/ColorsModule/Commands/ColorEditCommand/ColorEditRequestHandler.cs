using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.ColorsModule.Commands.ColorEditCommand
{
    class ColorEditRequestHandler : IRequestHandler<ColorEditRequest, Color>
    {
        private readonly IColorRepository colorRepository;

        public ColorEditRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }

        public async Task<Color> Handle(ColorEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await colorRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            entity.Name = request.Name;
            entity.HexCode = request.HexCode;

            await colorRepository.EditAsync(entity);
            await colorRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
