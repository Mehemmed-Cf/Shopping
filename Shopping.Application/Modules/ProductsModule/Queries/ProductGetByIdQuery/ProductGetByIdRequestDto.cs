using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.ProductsModule.Queries.ProductGetByIdQuery
{
    public class ProductGetByIdRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public short Price { get; set; }
        public int StockCount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }

        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public string SizeSmallName { get; set; }

        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string HexCode { get; set; }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
