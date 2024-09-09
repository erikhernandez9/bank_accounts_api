using System.Collections.Generic;

namespace MyApi.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(string id);
        User AddUser(User user);
        User UpdateUser(string id, User updatedUser);
        void DeleteUser(string id);
    }
}