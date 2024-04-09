using UsersAPI.Data;
using UsersAPI.Interfaces;
using UsersAPI.Models;

namespace UsersAPI.Repository 
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersdbContext _context;
        public UserRepository(UsersdbContext context) 
        {
            _context = context;
        }

        public User GetUser(int userId)
        {
            return _context.Users.Where(u => u.Userid == userId).FirstOrDefault();
        }
        public User GetUser(string login)
        {
            return _context.Users.Where(u => u.Login == login).FirstOrDefault();
        }

        public ICollection<User> GetUsers() 
        {
            return  _context.Users.OrderBy(u => u.Userid).ToList();
        }

        public bool UserExist(int userId)
        {
            return _context.Users.Any(u => u.Userid == userId);
        }

        public bool UserExist(string login)
        {
            return _context.Users.Any(u => u.Login == login);
        }
    }
}
