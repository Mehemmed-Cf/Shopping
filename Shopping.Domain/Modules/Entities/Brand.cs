using Shopping.Infrastructure.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Modules.Entities
{
    public class Brand : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
