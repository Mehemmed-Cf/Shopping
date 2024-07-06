using MediatR;
using Shopping.Domain.Models.Entities;

namespace Shopping.Application.Modules.CategoriesModule.Queries.CategoryGetAllQuery
{
    public class CategoryGetAllRequest : IRequest<IEnumerable<CategoryRequestDto>> //Category
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
