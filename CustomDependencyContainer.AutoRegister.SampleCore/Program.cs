using System;
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
}
