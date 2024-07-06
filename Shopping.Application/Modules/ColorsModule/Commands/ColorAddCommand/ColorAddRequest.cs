using MediatR;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.ColorsModule.Commands.ColorAddCommand
{
    public class ColorAddRequest : IRequest<Color>
    {
        public string Name { get; set; }
        public string HexCode { get; set; }
        public string State { get; set; } //A,B,C,D,E
    }
}
