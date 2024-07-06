using MediatR;
using Shopping.Domain.Models.Entities;
using Shopping.Domain.Models.Stables;

namespace Shopping.Application.Modules.CategoriesModule.Queries.CategoryGetAllSafeQuery
{
    public class CategoryGetAllSafeRequest : IRequest<IEnumerable<Category>>
    {
        public int Id { get; set; }
        public CategoryType Type { get; set; }
    }
}
