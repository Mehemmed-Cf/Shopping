using Shopping.Infrastructure.Exceptions;

namespace Shopping.Infrastructure.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException()
            : base("Username or Password is incorrect")
        {
        }
    }
}
