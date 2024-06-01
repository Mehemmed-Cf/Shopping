using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.BrandsModule.Queries.BrandGetAllQuery
{
    public class BrandGetAllRequest : IRequest<IEnumerable<BrandRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
