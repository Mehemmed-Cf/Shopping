using MediatR;
using Shopping.Domain.Models.Stables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.CategoriesModule.Commands.CategoryEditCommand
{
    public class CategoryEditRequest : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
        public int? ParentId { get; set; }
    }
}
