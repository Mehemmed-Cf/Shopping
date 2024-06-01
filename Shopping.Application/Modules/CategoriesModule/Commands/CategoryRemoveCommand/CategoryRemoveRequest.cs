using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.CategoriesModule.Commands.CategoryRemoveCommand
{
    public class CategoryRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
