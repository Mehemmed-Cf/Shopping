using MediatR;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.SizesModule.Commands.SizeEditCommand
{
    public class SizeEditRequest : IRequest<Size>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SmallName { get; set; }
    }
}
