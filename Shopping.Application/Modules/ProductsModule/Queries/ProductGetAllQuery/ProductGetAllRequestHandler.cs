using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using Shopping.Infrastructure.Exceptions;
using static Dapper.SqlMapper;

namespace Shopping.Application.Modules.ProductsModule.Queries.ProductGetAllQuery
{
    class ProductGetAllRequestHandler : IRequestHandler<ProductGetAllRequest, IEnumerable<ProductGetAllRequestDto>>
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMaterialRepository materialRepository;
        private readonly IColorRepository colorRepository;
        private readonly ISizeRepository sizeRepository;
        private readonly IBrandRepository brandRepository;
        private readonly IActionContextAccessor ctx;

        public ProductGetAllRequestHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMaterialRepository materialRepository, IColorRepository colorRepository, ISizeRepository sizeRepository, IBrandRepository brandRepository, IActionContextAccessor ctx)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.materialRepository = materialRepository;
            this.colorRepository = colorRepository;
            this.sizeRepository = sizeRepository;
            this.brandRepository = brandRepository;
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

            var categorySet = await categoryRepository.GetAll(m => m.DeletedAt == null).ToDictionaryAsync(c => c.Id, cancellationToken);
            var materialSet = await materialRepository.GetAll(m => m.DeletedAt == null).ToDictionaryAsync(m => m.Id, cancellationToken);
            var brandSet = await brandRepository.GetAll(m => m.DeletedAt == null).ToDictionaryAsync(b => b.Id, cancellationToken);
            var colorSet = await colorRepository.GetAll(m => m.DeletedAt == null).ToDictionaryAsync(c => c.Id, cancellationToken);
            var sizeSet = await sizeRepository.GetAll(m => m.DeletedAt == null).ToDictionaryAsync(s => s.Id, cancellationToken);

            /*            var productSet = productRepository.GetAll();
                        var categorySet = categoryRepository.GetAll();
                        var materialSet = materialRepository.GetAll();
                        var brandSet = brandRepository.GetAll();
                        var colorSet = colorRepository.GetAll();
                        var sizeSet = sizeRepository.GetAll();*/

            var queryResponse = await query.Select(m => new ProductGetAllRequestDto
            {
                Id = m.Id,
                Title = m.Title,
                ImageUrl = $"{host}/uploads/images/{m.ImagePath}",
                Price = m.Price,
                StockCount = m.StockCount,
                CategoryName = categorySet.ContainsKey(m.CategoryId) ? categorySet[m.CategoryId].Name : null,
                BrandName = brandSet.ContainsKey(m.BrandId) ? brandSet[m.BrandId].Name : null,
                ColorName = colorSet.ContainsKey(m.ColorId) ? colorSet[m.ColorId].Name : null,
                HexCode = colorSet.ContainsKey(m.ColorId) ? colorSet[m.ColorId].HexCode : null,
                SizeName = sizeSet.ContainsKey(m.SizeId) ? sizeSet[m.SizeId].Name : null,
                SizeSmallName = sizeSet.ContainsKey(m.SizeId) ? sizeSet[m.SizeId].SmallName : null,
                MaterialName = materialSet.ContainsKey(m.MaterialId) ? materialSet[m.MaterialId].Name : null,
            }).ToListAsync(cancellationToken);

            /*            var queryResponse = await query.Select(m => new ProductGetAllRequestDto
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
                        }).ToListAsync(cancellationToken);*/

            return queryResponse;
        }
    }
}
