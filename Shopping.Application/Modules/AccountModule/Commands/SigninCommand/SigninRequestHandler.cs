using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Shopping.Domain.Models.Entities.Membership;
using Shopping.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.AccountModule.Commands.SigninCommand
{
    class SigninRequestHandler : IRequestHandler<SigninRequest, ClaimsPrincipal>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signinManager;
        private readonly  IHttpContextAccessor httpContextAccessor;

        public SigninRequestHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
            this.signinManager = signinManager;
        }

        public async Task<ClaimsPrincipal> Handle(SigninRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.UserName);

            if (user is null)
                throw new UserNotFoundException();

            var hasher = new PasswordHasher<AppUser>();

            if (hasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Success)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                };

                var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

                var authenticationManager = httpContextAccessor.HttpContext;

                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                        new ClaimsPrincipal(claimsIdentity),
                                                        new AuthenticationProperties
                                                        {
                                                            IsPersistent = true,
                                                            ExpiresUtc = DateTime.UtcNow.AddDays(14) // AddMinutes(20)
                                                        });

                return new ClaimsPrincipal(claimsIdentity);
            }
            else
                throw new UserNotFoundException();
        }
    }
}
