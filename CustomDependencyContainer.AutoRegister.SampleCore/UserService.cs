using System;
using System.Collections.Generic;

namespace CustomDependencyContainer.AutoRegister.SampleCore
{
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

}
