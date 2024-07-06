using MediatR;
using Shopping.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.CategoriesModule.Queries.CategoryGetHierarcialQuery
{
    public class CategoryGetHierarcialRequest : IRequest<IEnumerable<Category>>
    {

    }
}
