using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace CustomDependencyContainer.AutoRegister.SampleCore
{
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
