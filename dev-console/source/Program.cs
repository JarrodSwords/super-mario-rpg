using System.Reflection;
using Autofac;
using SuperMarioRpg.GameDevelopment.CharacterManagement;

namespace DevConsole
{
    internal class Program
    {
        private static readonly Assembly[] Assemblies =
        {
            typeof(AutofacModule).Assembly,
            typeof(CreateCharacter).Assembly
        };

        #region Static Interface

        private static void Main(string[] args)
        {
            AutofacModule
                .CreateContainer(Assemblies)
                .Resolve<Application>()
                .Run();
        }

        #endregion
    }
}
