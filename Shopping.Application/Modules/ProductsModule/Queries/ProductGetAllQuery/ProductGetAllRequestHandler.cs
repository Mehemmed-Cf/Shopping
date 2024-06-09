using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;

namespace Shopping.Application.Modules.ProductsModule.Queries.ProductGetAllQuery
{
    class ProductGetAllRequestHandler : IRequestHandler<ProductGetAllRequest, IEnumerable<ProductGetAllRequestDto>>
    {
        private readonly IProductRepository productRepository;
        private readonly IActionContextAccessor ctx;

        public ProductGetAllRequestHandler(IProductRepository productRepository, IActionContextAccessor ctx)
        {
            this.productRepository = productRepository;
            this.ctx = ctx;
        }

        public async Task<IEnumerable<ProductGetAllRequestDto>> Handle(ProductGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = productRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }

            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";

            var queryResponse = await query.Select(m => new ProductGetAllRequestDto
            {
                Id = m.Id,
                Title = m.Title,
                ImageUrl = $"{host}/uploads/images/{m.ImagePath}",
                Price = m.Price,
                StockCount = m.StockCount,
                CategoryName = "Demo",
                BrandName = "Demo Brand",
                ColorName = "Demo Color",
                HexCode = "Demo Hex",
                SizeName = "Demo Size",
                SizeSmallName = "Demo SmallName",
                MaterialName = "Demo Material",
            }).ToListAsync(cancellationToken);

            return queryResponse;
        }
    }
}
