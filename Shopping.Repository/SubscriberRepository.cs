using Microsoft.EntityFrameworkCore;
using Shopping.Application.Repositories;
using Shopping.Domain.Models.Entities;
using Shopping.Infrastructure.Concrates;

namespace Shopping.Repository
{
    class SubscriberRepository : AsyncRepository<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(DbContext db) : base(db)
        {
        }

        public async Task<Subscriber> GetByEmailAsync(string email)
        {
            return await db.Set<Subscriber>().FirstOrDefaultAsync(s => s.Email == email);
        }
    }
}
