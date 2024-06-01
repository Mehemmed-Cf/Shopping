using Shopping.Infrastructure.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Models.Entities
{
    public class Product : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public short Price { get; set; }
        public int StockCount { get; set; }

        public int CategoryId { get; set; }

        public int MaterialId { get; set; }

        public int SizeId { get; set; }

        public int ColorId { get; set; }
        public int BrandId { get; set; }

        public string ImagePath { get; set; }
    }
}
