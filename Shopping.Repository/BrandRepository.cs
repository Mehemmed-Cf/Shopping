using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using Shopping.Infrastructure.Concrates;
using Shopping.Domain.Models.Entities;

namespace Shopping.Repository
{
    class BrandRepository : AsyncRepository<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext db) : base(db)
        {

        }
    }
}
