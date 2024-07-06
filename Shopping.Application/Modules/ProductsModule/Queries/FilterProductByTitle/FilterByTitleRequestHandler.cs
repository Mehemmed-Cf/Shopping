using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Modules.ProductsModule.Queries.ProductGetByIdQuery;
using Shopping.Application.Repositories;
using Shopping.Infrastructure.Exceptions;

namespace Shopping.Application.Modules.ProductsModule.Queries.FilterProductByTitle
{
    class FilterByTitleRequestHandler : IRequestHandler<FilterByTitleRequest, IEnumerable<FilterByTitleRequestDto>>
    {
        private readonly IProductRepository productRepository;
        private readonly IActionContextAccessor ctx;

        public FilterByTitleRequestHandler(IProductRepository productRepository, IActionContextAccessor ctx)
        {
            this.productRepository = productRepository;
            this.ctx = ctx;
        }

        public async Task<IEnumerable<FilterByTitleRequestDto>> Handle(FilterByTitleRequest request, CancellationToken cancellationToken)
        {
            var productSet = productRepository.GetAll(m => m.DeletedAt == null && m.Title.Contains(request.Title));

            if (productSet == null)
            {
                throw new NotFoundException($"Product with ID {request.Title} not found.");
            }

            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";

            var joinedQuery = await (from p in productSet
                                     select new FilterByTitleRequestDto
                                     {
                                         Id = p.Id,
                                         Title = p.Title,
                                         ImageUrl = $"{host}/uploads/images/{p.ImagePath}",
                                         Price = p.Price,
                                     }).ToListAsync(cancellationToken);

            if (joinedQuery == null)
            {
                return null;
            }

            return joinedQuery;
        }
    }
}
