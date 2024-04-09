using UsersAPI.Models;

namespace UsersAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int userid);
        User GetUser(string login);
        bool UserExist(int userId);
        bool UserExist(string login);

    }
}
