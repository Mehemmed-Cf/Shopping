using MediatR;

namespace Shopping.Application.Modules.UsersModule.Queries.GetAllQuery
{
    public class UserGetAllRequest : IRequest<IEnumerable<AppUserDto>>
    {
    }
}
