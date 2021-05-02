
using System.Collections.Generic;


namespace CustomDependencyContainer.AutoRegister.SampleCore
{
    /// <summary>
    /// Interface sample IUserService
    /// </summary>
    public interface IUserService
    {
        bool Authorize(string username, string password);
        IList<string> UserList();
    }
}
