using Shopping.Domain.Models.Stables;
using Shopping.Infrastructure.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Models.Entities
{
    public class Category : AuditableEntity
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
    }
}
