# Custom Dependency Container

Conteneur de dépendance pour projet dotnet utile pour appliquer les principes SOLID



## Exemple d'utilisation

```

using System;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace CustomDependencyContainer.AutoRegister.SampleCore
{
    class Program
    {
        static void Main(string[] args)
        {
            UnityAutoRegister.InstantiateAll(new UnityContainer());

            var service = UnityAutoRegister.Container.Resolve<UserViewModel>();

            if (service.Authorize("test", "test"))
            {
                Console.WriteLine("OK");
            }

            Console.ReadLine();
        }


    }

    /// <summary>
    /// Interface sample IUserService
    /// </summary>
    /// 
    public interface IUserService
    {
        bool Authorize(string username, string password);
        IList<string> UserList();
    }

    /// <summary>
    /// Implémentation de l'interface IUserService utilisant le ImplementAttribute
    /// </summary>
    /// 

    [Implement(typeof(IUserService))]
    public class UserService : IUserService
    {
        public bool Authorize(string username, string password)
        {
            return username.Equals("test", StringComparison.InvariantCultureIgnoreCase) &&
                   password.Equals("test", StringComparison.InvariantCultureIgnoreCase);
        }

        public IList<string> UserList()
        {
            return new List<string>() { "User 1", "User 2", "User 3" };
        }
    }

    public class UserViewModel
    {

        private readonly IUserService service;

        [InjectionConstructor]
        public UserViewModel(IUserService userService)
        {
            service = userService;
        }

        public bool Authorize(string username, string password)
        {
            return service.Authorize(username, password);
        }

        public List<string> List => service.UserList().ToList();


    }



}

```
