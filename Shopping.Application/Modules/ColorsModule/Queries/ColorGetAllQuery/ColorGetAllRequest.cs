using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.ColorsModule.Queries.ColorGetAllQuery
{
    public class ColorGetAllRequest : IRequest<IEnumerable<ColorRequestDto>> 
    {
        public bool OnlyAvailable { get; set; } = true;  
    }
}
