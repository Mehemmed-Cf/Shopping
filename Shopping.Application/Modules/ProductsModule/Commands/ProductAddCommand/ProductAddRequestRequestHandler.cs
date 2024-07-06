using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;
using Shopping.Infrastructure.Abstracts;

namespace Shopping.Application.Modules.ProductsModule.Commands.ProductAddCommand
{
    class ProductAddRequestRequestHandler : IRequestHandler<ProductAddRequest, ProductAddRequestDto>
    {
        private readonly IProductRepository productRepository;
        private readonly IFileService fileService;

        public ProductAddRequestRequestHandler(IProductRepository productRepository, IFileService fileService)
        {
            this.productRepository = productRepository;
            this.fileService = fileService;
        }

        public async Task<ProductAddRequestDto> Handle(ProductAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                Title = request.Title,
                CategoryId = request.CategoryId,
                Price = request.Price,
                StockCount = request.StockCount,
                MaterialId = request.MaterialId,
                BrandId = request.BrandId,
                SizeId = request.SizeId,
                ColorId = request.ColorId,
                CreatedBy = 1, 
                CreatedAt = DateTime.UtcNow
            };

            entity.ImagePath = await fileService.UploadAsync(request.Image);

            await productRepository.AddAsync(entity);
            await productRepository.SaveAsync(cancellationToken);

            var dto = new ProductAddRequestDto
            {
                Id = entity.Id,
                Title = request.Title,
                ImageUrl = entity.ImagePath,

                //might be wrong
            };

            return dto;
        }
    }
}
