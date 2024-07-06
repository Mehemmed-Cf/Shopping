using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Dtos;
using Shopping.Domain.Models.Entities;
using Shopping.Domain.Models.Stables;
using Shopping.Infrastructure.Concrates;
using Shopping.Infrastructure.Extensions;

namespace Shopping.Repository
{
    class CategoryRepository : AsyncRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<RelatedCategoryIds>> GetRelatedIds(int id)
        {
            var idParameter = new SqlParameter("@id", id);
            return await db.Database.SqlQueryRaw<RelatedCategoryIds>($"dbo.spGetRelatedIds @id", idParameter)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetSafeCategories(int id, CategoryType type)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            parameters.Add("@type", (int)type);

            return await db.QueryAsync<Category>("[dbo].[spGetAllSafeCategories]", parameters);
        }
    }
}
