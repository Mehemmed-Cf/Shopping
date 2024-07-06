using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.ProductsModule.Commands.ProductEditCommand
{
    public class ProductEditRequest : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public short Price { get; set; }
        public int StockCount { get; set; }
        public int CategoryId { get; set; }
        public int MaterialId { get; set; }

        public int SizeId { get; set; }

        public int ColorId { get; set; }

        public int BrandId { get; set; }
    }
}
