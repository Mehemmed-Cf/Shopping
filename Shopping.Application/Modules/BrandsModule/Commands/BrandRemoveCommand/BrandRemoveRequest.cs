using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.BrandsModule.Commands.BrandRemoveCommand
{
    public class BrandRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
