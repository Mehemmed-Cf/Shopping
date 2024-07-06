using Shopping.Infrastructure.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Models.Entities
{
    public class Color : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
    }
}
