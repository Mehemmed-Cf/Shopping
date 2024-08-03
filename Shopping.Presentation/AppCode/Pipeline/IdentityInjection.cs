﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Shopping.Domain.Models.Entities.Membership;
using Shopping.Infrastructure.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Shopping.Api.AppCode.Pipeline
{
    static class IdentityInjection
    {
        internal static IServiceCollection AddCustomIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityCore<AppUser>()
             .AddRoles<AppRole>()
             .AddDefaultTokenProviders()
             .AddEntityFrameworkStores<DbContext>();

            services.AddScoped<SignInManager<AppUser>>();
            services.AddScoped<UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>>();
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IClaimsTransformation, AppClaimsTransformation>();

            services.Configure<IdentityOptions>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                // cfg.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                cfg.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                cfg.Lockout.AllowedForNewUsers = true;
                cfg.Lockout.MaxFailedAccessAttempts = 3;

                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequiredUniqueChars = 1;
                cfg.Password.RequiredLength = 3;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                //options.LoginPath = "/Account/Login";
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/NotAllowed";
                options.SlidingExpiration = true;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    //options.LoginPath = "/Account/Login";
                    options.LoginPath = "/Login";
                    options.AccessDeniedPath = "/NotAllowed";
                });

            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("RequireSuperAdminRole", policy => policy.RequireRole("SUPERADMIN"));

                foreach (var item in AppClaimsTransformation.policies)
                {
                    cfg.AddPolicy(item, p =>
                    {
                        // p.RequireClaim(item, "1");

                        p.RequireAssertion(handler => handler.User.IsInRole("SUPERADMIN") || handler.User.HasClaim(item, "1"));
                        // p.RequireAssertion(handler => handler.User.HasClaim(item, "1"));
                    });
                }
            });

            return services;
        }
    }
}
