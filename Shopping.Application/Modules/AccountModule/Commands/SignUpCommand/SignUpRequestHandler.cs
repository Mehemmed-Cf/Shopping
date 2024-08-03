﻿using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shopping.Domain.Models.Entities.Membership;
using System.Security.Claims;

namespace Shopping.Application.Modules.AccountModule.Commands.SignUpCommand
{
    class SignUpRequestHandler : IRequestHandler<SignUpRequest, ClaimsPrincipal>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signinManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SignUpRequestHandler(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<ClaimsPrincipal> Handle(SignUpRequest request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                UserName = request.Email,
                Email = request.Email,
                Name = request.FirstName,
                Surname = request.LastName
            };

            var result = await userManager.CreateAsync(user, request.Password);


            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.GivenName, user.Name),
                    new Claim(ClaimTypes.Surname, user.Surname)
                };


                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authenticationManager = httpContextAccessor.HttpContext;

                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                        new ClaimsPrincipal(claimsIdentity),
                                                        new AuthenticationProperties
                                                        {
                                                            IsPersistent = true,
                                                            ExpiresUtc = DateTime.UtcNow.AddDays(14)
                                                        });

                return new ClaimsPrincipal(claimsIdentity);
            }
            else
            {
                throw new Exception("Failed to create user. " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
