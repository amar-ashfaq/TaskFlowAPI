using TaskFlowAPI.Data;
using TaskFlowAPI.Entities;

namespace TaskFlowAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public User GetUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null) 
            {
                throw new KeyNotFoundException($"User with id {id} could not be found");
            }

            return user;
        }

        public User GetUserByUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == username);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with username {username} could not be found");
            }

            return user;
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void UpdateUser()
        {
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = GetUser(id);

            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
