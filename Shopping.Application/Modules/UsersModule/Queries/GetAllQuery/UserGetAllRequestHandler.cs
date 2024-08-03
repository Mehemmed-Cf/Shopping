using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Modules.SubscribersModule.Queries;
using Shopping.Application.Repositories;

namespace Shopping.Application.Modules.UsersModule.Queries.GetAllQuery
{
    public class UserGetAllRequestHandler : IRequestHandler<UserGetAllRequest, IEnumerable<AppUserDto>>
    {
        private readonly IUserRepository userRepository;

        public UserGetAllRequestHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IEnumerable<AppUserDto>> Handle(UserGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = userRepository.GetAll();

            var response = await query.Select(m => new AppUserDto
            {
                Id = m.Id,
                Password = m.PasswordHash,
                Email = m.Email,
            }).ToListAsync(cancellationToken);

            return response;
        }
    }
}
