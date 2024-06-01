using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.CategoriesModule.Commands.CategoryAddCommand
{
    class CategoryAddRequestHandler : IRequestHandler<CategoryAddRequest>
    {
        public Task Handle(CategoryAddRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
