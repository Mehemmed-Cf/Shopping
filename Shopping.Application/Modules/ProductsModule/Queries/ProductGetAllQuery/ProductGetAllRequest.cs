using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.ProductsModule.Queries.ProductGetAllQuery
{
    public class ProductGetAllRequest : IRequest<IEnumerable<ProductGetAllRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
