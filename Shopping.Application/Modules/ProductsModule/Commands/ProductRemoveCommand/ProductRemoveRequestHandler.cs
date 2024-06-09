using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;
using Shopping.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.ProductsModule.Commands.ProductRemoveCommand
{
    class ProductRemoveRequestHandler : IRequestHandler<ProductRemoveRequest>
    {
        private readonly IProductRepository productRepository;

        public ProductRemoveRequestHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task Handle(ProductRemoveRequest request, CancellationToken cancellationToken)
        {
            Product entity;

            if (request.OnlyAvailable)
            {
                entity = await productRepository.GetAsync(m => m.Id == request.Id && m.DeletedBy == null, cancellationToken);
            }
            else
            {
                entity = await productRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            }

            productRepository.Remove(entity);
            await productRepository.SaveAsync(cancellationToken);
        }
    }
}
