using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Unity;

namespace CustomDependencyContainer.AutoRegister
{
    /// <summary>
    /// Classe utilisée pour l'injection des objets du projet
    /// </summary>
    public class UnityAutoRegister
    {
        /// <summary>
        /// Conteneur de dépendance
        /// </summary>
        public static IUnityContainer Container { set; get; }

        public static void InstantiateAll(IUnityContainer c)
        {
            if (c == null) return;
            if (Container == null)
            {
                Container = c;
            }


            List<Assembly> list = AppDomain.CurrentDomain.GetCurrentDirectoryAssembly();
            foreach (Assembly assembly in list)
            {
                IEnumerable<Type> types = from type in GetLoadableTypes(assembly)
                                          where Attribute.IsDefined(type, typeof(ImplementAttribute))
                                          select type;


                foreach (Type to in types)
                {
                    ImplementAttribute custom = to.GetCustomAttributes<ImplementAttribute>().SingleOrDefault();
                    if (custom != null)
                    {
                        Container.RegisterType(custom.FromType, to);
                    }

                }

            }
        }




        private static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }

    internal static class AppDomainExtension
    {
        public static List<Assembly> GetCurrentDirectoryAssembly(this AppDomain domain)
        {
            var assemblies = new List<Assembly>();

            DirectoryInfo d = new DirectoryInfo(domain.BaseDirectory);
            FileInfo[] Files = d.GetFiles("*.dll");
            foreach (FileInfo file in Files)
            {
                assemblies.Add(Assembly.LoadFrom(file.Name));
            }
            var newAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .ToList()
                .Where(assembly => !assemblies.Any(oldAssembly => oldAssembly.Equals(assembly)))
                .ToList();

            assemblies.AddRange(newAssemblies);
            return assemblies;
        }
    }
}
