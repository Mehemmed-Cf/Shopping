using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using Shopping.Domain.Modules.Entities;
using Shopping.Infrastructure.Concrates;

namespace Shopping.Repository
{
    internal class BlogPostRepository : AsyncRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(DbContext db) : base(db)
        {
        }
    }
}
