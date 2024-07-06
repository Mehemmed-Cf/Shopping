using MediatR;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.CategoriesModule.Queries.CategoryGetAllSafeQuery
{
    class CategoryGetAllSafeRequestHandler : IRequestHandler<CategoryGetAllSafeRequest, IEnumerable<Category>>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryGetAllSafeRequestHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Task<IEnumerable<Category>> Handle(CategoryGetAllSafeRequest request, CancellationToken cancellationToken)
        {
            return categoryRepository.GetSafeCategories(request.Id, request.Type);
        }
    }
}
