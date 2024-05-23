using Autofac;
using Shopping.Application;
using Shopping.DataAccessLayer;
using Shopping.Repository;

namespace Shopping.Presentation.AppCode.DI
{
    public class ShoppingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //builder.RegisterModule<DataAccessModule>();

            builder.RegisterAssemblyModules(typeof(DataAccessModule).Assembly);
            builder.RegisterAssemblyModules(typeof(ApplicationModule).Assembly);

            builder.RegisterAssemblyTypes(typeof(IRepositoryReference).Assembly)
                .AsImplementedInterfaces();
        }
    }
}
