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
            typeof(Character).Assembly
        };

        #region Private Interface

        private static IContainer Container { get; set; }

        #endregion

        #region Static Interface

        private static void Main(string[] args)
        {
            Container = AutofacModule.Create(Assemblies);

            Container.Resolve<Application>().Run();
        }

        #endregion
    }
}
