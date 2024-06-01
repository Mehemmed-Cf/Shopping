using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.SizesModule.Queries.SizeGetAllQuery
{
    public class SizeGetAllRequest : IRequest<IEnumerable<SizeRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
