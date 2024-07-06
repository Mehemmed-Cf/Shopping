using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.CategoriesModule.Queries.CategoryGetHierarcialQuery
{
    class CategoryGetHierarcialRequestHandler : IRequestHandler<CategoryGetHierarcialRequest, IEnumerable<Category>>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryGetHierarcialRequestHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> Handle(CategoryGetHierarcialRequest request, CancellationToken cancellationToken)
        {
            var categories = await categoryRepository.GetAll(m => m.DeletedAt == null).ToListAsync(cancellationToken);

            return GetAllChildren(categories, null);
        }

        IEnumerable<Category> GetAllChildren(IEnumerable<Category> categories, Category parent)
        {
            if (parent != null)
                yield return parent;


            foreach (var item in categories.Where(m => m.ParentId == parent?.Id).SelectMany(m => GetAllChildren(categories, m)))
            {
                yield return item;
            }
        }
    }
}
