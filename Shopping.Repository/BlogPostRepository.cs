using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;
using Shopping.Infrastructure.Concrates;

namespace Shopping.Repository
{
    class BlogPostRepository : AsyncRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(DbContext db) : base(db)
        {
        }
    }
}
