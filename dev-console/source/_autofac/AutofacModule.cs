using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace DevConsole
{
    public class AutofacModule : Module
    {
        #region Protected Interface

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(AutofacModule).Assembly);

            builder
                .RegisterType<MainMenu>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            builder
                .RegisterType<CharacterManagementMenu>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
        }

        #endregion

        #region Static Interface

        public static IContainer CreateContainer(params Assembly[] assemblies)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(assemblies);

            return builder.Build();
        }

        #endregion
    }
}
