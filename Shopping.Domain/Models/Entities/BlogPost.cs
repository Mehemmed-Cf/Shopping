using Shopping.Infrastructure.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Models.Entities
{
    public class BlogPost : AuditableEntity  
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }

        public int? PublishedBy { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}
