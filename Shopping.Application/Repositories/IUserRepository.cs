using Shopping.Domain.Models.Entities.Membership;
using Shopping.Infrastructure.Abstracts;

namespace Shopping.Application.Repositories
{
    public interface IUserRepository : IAsyncRepository<AppUser>
    {
    }
}
