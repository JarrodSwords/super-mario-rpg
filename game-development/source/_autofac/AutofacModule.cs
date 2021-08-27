using Autofac;
using SuperMarioRpg.GameDevelopment.CharacterManagement;

namespace SuperMarioRpg.GameDevelopment
{
    public class AutofacModule : Module
    {
        #region Protected Interface

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(AutofacModule).Assembly)
                .Except<Character>()
                .AsImplementedInterfaces();
        }

        #endregion
    }
}
