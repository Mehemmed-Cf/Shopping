using Shopping.Application.Services.File;
using Shopping.Application.Services;
using Shopping.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Shopping.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<JwtService>()
                .As<IJwtService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CryptoService>()
                .As<ICryptoService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FileService>()
            .As<IFileService>()
            .InstancePerLifetimeScope();

            //builder.RegisterType<ValidatorInterceptor>()
            //    .As<IValidatorInterceptor>()
            //    .SingleInstance();
        }
    }
}
