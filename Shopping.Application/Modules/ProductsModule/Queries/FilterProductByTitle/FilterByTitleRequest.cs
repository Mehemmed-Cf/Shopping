using MediatR;

namespace Shopping.Application.Modules.ProductsModule.Queries.FilterProductByTitle
{
    public class FilterByTitleRequest : IRequest<IEnumerable<FilterByTitleRequestDto>>
    {
        public string Title { get; set; }
    }
}
