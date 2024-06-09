using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.CategoriesModule.Queries.CategoryGetByIdQuery
{
    public class CategoryGetByIdRequestHandler : IRequestHandler<CategoryGetByIdRequest, CategoryGetByIdDto>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryGetByIdRequestHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<CategoryGetByIdDto> Handle(CategoryGetByIdRequest request, CancellationToken cancellationToken)
        {
            var dto = await (from c in categoryRepository.GetAll(m => m.DeletedAt == null)
                             join p in categoryRepository.GetAll() on c.ParentId equals p.Id into leftJoin
                             from l in leftJoin.DefaultIfEmpty()
                             where c.Id == request.Id
                             select new CategoryGetByIdDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 ParentId = c.ParentId,
                                 ParentName = l.Name,
                                 Type = c.Type,
                             }).FirstOrDefaultAsync(cancellationToken);

            return dto;
        }
    }
}
