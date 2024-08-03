using Microsoft.EntityFrameworkCore;
using Shopping.Application;
using Shopping.DataAccessLayer.DataContexts;
using Shopping.Infrastructure.Abstracts;
using Shopping.Presentation.AppCode.DI;
using Shopping.Application.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Shopping.Application.Services.File;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using MediatR;
using Shopping.Api.AppCode.Pipeline;
using Shopping.Infrastructure.Configurations;

namespace Shopping.Presentation
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new ShoppingServiceProviderFactory());

            builder.Services.AddCors(cfg =>
            {

                cfg.AddPolicy("allowAll", p =>
                {

                    p.AllowAnyHeader();
                    p.AllowAnyMethod();
                    p.AllowAnyOrigin();

                });

            });

            builder.Services.AddControllers(cfg =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                  .RequireAuthenticatedUser()
                                  .Build();

                cfg.Filters.Add(new AuthorizeFilter(policy));
            });

            builder.Services.AddDbContext<DbContext, DataContext>(cfg =>
            {
                string cs = builder.Configuration.GetConnectionString("cString");

                cfg.UseSqlServer(cs, opt =>
                {
                    opt.MigrationsHistoryTable("MigrationHistory");
                });
            });

            builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(HeaderBinderBehaviour<,>));

            builder.Services.Configure<CryptoServiceOptions>(cfg => builder.Configuration.Bind(nameof(CryptoServiceOptions), cfg));
            builder.Services.AddCustomIdentity(builder.Configuration);

            builder.Services.AddScoped<IIdentityService, FakeIdentityService>();

            builder.Services.AddSingleton<IFileService, FileService>();

            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);

            /*builder.Services.AddFluentValidationAutoValidation(cfg => cfg.DisableDataAnnotationsValidation = false);*/

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<IApplicationReferance>());

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseCors("allowAll");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseErrorHandling();

            app.MapControllers();

            app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");

            app.Run();
        }
    }
}