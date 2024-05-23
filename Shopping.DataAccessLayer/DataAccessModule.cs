using Autofac;
using Microsoft.EntityFrameworkCore;
using Shopping.DataAccessLayer.DataContexts;

namespace Shopping.DataAccessLayer
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DataContext>()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}
