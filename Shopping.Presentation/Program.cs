using Microsoft.EntityFrameworkCore;
using Shopping.Application;
using Shopping.DataAccessLayer.DataContexts;
using Shopping.Infrastructure.Abstracts;
using Shopping.Presentation.AppCode.DI;
using Shopping.Application.Services;
using FluentValidation.AspNetCore;

namespace Shopping.Presentation
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new ShoppingServiceProviderFactory());

            builder.Services.AddDbContext<DbContext, DataContext>(cfg =>
            {
                string cs = builder.Configuration.GetConnectionString("cString");

                cfg.UseSqlServer(cs, opt =>
                {
                    opt.MigrationsHistoryTable("MigrationHistory");
                });
            });

            builder.Services.AddScoped<IIdentityService, FakeIdentityService>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);

            /*builder.Services.AddFluentValidationAutoValidation(cfg => cfg.DisableDataAnnotationsValidation = false);*/

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<IApplicationReferance>()); // Butun repositoriler

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");

            app.Run();
        }
    }
}