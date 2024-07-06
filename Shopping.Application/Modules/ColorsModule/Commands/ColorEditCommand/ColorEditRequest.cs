using MediatR;
using Shopping.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.ColorsModule.Commands.ColorEditCommand
{
    public class ColorEditRequest : IRequest<Color>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
    }
}
