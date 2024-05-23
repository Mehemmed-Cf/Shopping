using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace Shopping.Presentation.AppCode.DI
{
    public class ShoppingServiceProviderFactory : AutofacServiceProviderFactory
    {
        public ShoppingServiceProviderFactory()
            : base(OnRegister)
        {
        }

        private static void OnRegister(ContainerBuilder builder)
        {
            builder.RegisterModule<ShoppingModule>();
        }
    }
}
