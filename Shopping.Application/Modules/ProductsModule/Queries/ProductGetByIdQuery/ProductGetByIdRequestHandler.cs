using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Modules.BlogPostsModule.Queries.BlogPostGetBySlugQuery;
using Shopping.Application.Repositories;
using Shopping.Infrastructure.Exceptions;

namespace Shopping.Application.Modules.ProductsModule.Queries.ProductGetByIdQuery
{
    class ProductGetByIdRequestHandler : IRequestHandler<ProductGetByIdRequest, ProductGetByIdRequestDto>
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMaterialRepository materialRepository;
        private readonly IColorRepository colorRepository;
        private readonly ISizeRepository sizeRepository;
        private readonly IBrandRepository brandRepository;
        private readonly IActionContextAccessor ctx;

        public ProductGetByIdRequestHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMaterialRepository materialRepository, IColorRepository colorRepository, ISizeRepository sizeRepository, IBrandRepository brandRepository, IActionContextAccessor ctx)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.materialRepository = materialRepository;
            this.colorRepository = colorRepository;
            this.sizeRepository = sizeRepository;
            this.brandRepository = brandRepository;
            this.ctx = ctx;
        }

        public async Task<ProductGetByIdRequestDto> Handle(ProductGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await productRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException($"Product with ID {request.Id} not found.");
            }

            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";

            var productSet = productRepository.GetAll();
            var categorySet = categoryRepository.GetAll();
            var materialSet = materialRepository.GetAll();
            var brandSet = brandRepository.GetAll();
            var colorSet = colorRepository.GetAll();
            var sizeSet = sizeRepository.GetAll();

            var joinedQuery = await (from p in productSet
                                     join ct in categorySet on p.CategoryId equals ct.Id
                                     join b in brandSet on p.BrandId equals b.Id
                                     join m in materialSet on p.MaterialId equals m.Id
                                     join s in sizeSet on p.SizeId equals s.Id
                                     join cl in colorSet on p.ColorId equals cl.Id
                                     where p.Id == request.Id && p.DeletedAt == null
                                     select new ProductGetByIdRequestDto
                                     {
                                         Id = p.Id,
                                         Title = p.Title,
                                         ImageUrl = $"{host}/uploads/images/{p.ImagePath}",
                                         CategoryId = p.CategoryId,
                                         CategoryName = ct.Name,
                                         BrandId = p.BrandId,
                                         BrandName = b.Name,
                                         ColorId = p.ColorId,
                                         ColorName = cl.Name,
                                         HexCode = cl.HexCode,
                                         SizeId = p.SizeId,
                                         SizeName = s.Name,
                                         SizeSmallName = s.SmallName,
                                         MaterialId = p.MaterialId,
                                         MaterialName = m.Name,
                                         Price = p.Price,
                                         StockCount = p.StockCount
                                     }).FirstOrDefaultAsync(cancellationToken);

            if (joinedQuery == null)
            {
                return null;
            }

            return joinedQuery;

            /*            return new ProductGetByIdRequestDto
                        {
                            Id = entity.Id,
                            Title = entity.Title,
                            Price = entity.Price,
                            StockCount = entity.StockCount,
                            ImageUrl = $"{host}/uploads/images/{entity.ImagePath}",
                            CategoryId = entity.CategoryId,
                            CategoryName = "Demo Category",
                            BrandId = entity.BrandId,
                            BrandName = "Demo Brand",
                            ColorId = entity.ColorId,
                            ColorName = "Demo Color",
                            SizeId = entity.SizeId,
                            SizeName = "Demo Size",
                            MaterialId = entity.MaterialId,
                            MaterialName = "Demo Material",
                        };*/
        }
    }
}
