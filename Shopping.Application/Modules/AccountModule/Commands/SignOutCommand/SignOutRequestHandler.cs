using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shopping.Domain.Models.Entities.Membership;

namespace Shopping.Application.Modules.AccountModule.Commands.SignOutCommand
{
    public class SignOutRequestHandler : IRequestHandler<SignOutRequest, bool>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SignOutRequestHandler(SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Handle(SignOutRequest request, CancellationToken cancellationToken)
        {


                await httpContextAccessor.HttpContext.SignOutAsync();

                return true;

        }
    }
}
