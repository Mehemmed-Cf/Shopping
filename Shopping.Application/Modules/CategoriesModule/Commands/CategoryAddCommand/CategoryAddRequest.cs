using MediatR;
using Shopping.Domain.Models.Stables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.CategoriesModule.Commands.CategoryAddCommand
{
    public class CategoryAddRequest : IRequest
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public CategoryType Type { get; set; }
    }
}
