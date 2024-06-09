using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.ProductsModule.Queries.ProductGetAllQuery
{
    public class ProductGetAllRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public short Price { get; set; }
        public int StockCount { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public string MaterialName { get; set; }
        public string SizeName { get; set; }
        public string SizeSmallName { get; set; }
        public string ColorName { get; set; }
        public string HexCode { get; set; }
        public string BrandName { get; set; }
    }
}
