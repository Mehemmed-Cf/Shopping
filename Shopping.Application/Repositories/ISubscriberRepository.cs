using Shopping.Domain.Models.Entities;
using Shopping.Infrastructure.Abstracts;

namespace Shopping.Application.Repositories
{
    public interface ISubscriberRepository : IAsyncRepository<Subscriber>
    {
        Task<Subscriber> GetByEmailAsync(string email);
    }
}
