using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities.Membership;
using Shopping.Infrastructure.Concrates;

namespace Shopping.Repository
{
    public class UserRepository : AsyncRepository<AppUser>, IUserRepository
    {
        public UserRepository(DbContext db) : base(db)
        {
        }
    }
}
