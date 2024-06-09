using Shopping.Domain.Models.Stables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.CategoriesModule.Queries.CategoryGetByIdQuery
{
    public class CategoryGetByIdDto
    {
        public int Id { get; set; }
        [DisplayName("Parent")]
        public int? ParentId { get; set; }
        public string ParentName { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
    }
}
