using Shopping.Domain.Models.Dtos;
using Shopping.Domain.Models.Entities;
using Shopping.Domain.Models.Stables;
using Shopping.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Repositories
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<IEnumerable<RelatedCategoryIds>> GetRelatedIds(int id);
        Task<IEnumerable<Category>> GetSafeCategories(int id, CategoryType type);
    }
}
