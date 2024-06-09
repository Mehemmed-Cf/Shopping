using MediatR;
using Shopping.Application.Repositories;
using Shopping.Infrastructure.Abstracts;

namespace Shopping.Application.Modules.ProductsModule.Commands.ProductEditCommand
{
    class ProductEditRequestHandler : IRequestHandler<ProductEditRequest>
    {
        private readonly IProductRepository productRepository;
        private readonly IFileService fileService;

        public ProductEditRequestHandler(IProductRepository productRepository, IFileService fileService)
        {
            this.productRepository = productRepository;
            this.fileService = fileService;
        }

        public async Task Handle(ProductEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await productRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            entity.Title = request.Title;
            entity.Price = request.Price;
            entity.StockCount = request.StockCount;
            entity.CategoryId = request.CategoryId;
            entity.ColorId = request.ColorId;
            entity.MaterialId = request.MaterialId;
            entity.BrandId = request.BrandId;
            entity.SizeId = request.SizeId;

            if (request.Image is not null)
                entity.ImagePath = await fileService.ChangeFileAsync(entity.ImagePath, request.Image);

            await productRepository.SaveAsync(cancellationToken);
        }
    }
}
