using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.MaterialsModule.Commands.MaterialRemoveCommand
{
    public class MaterialRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
