using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.ProductsModule.Queries.ProductGetByIdQuery
{
    public class ProductGetByIdRequest : IRequest<ProductGetByIdRequestDto>
    {
        public int Id { get; set; }
    }
}
