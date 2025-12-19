using TaskFlowAPI.Entities;

namespace TaskFlowAPI.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(int id);
        User GetUserByUsername(string username);

        User? FindUserByUsername(string username);
        void CreateUser(User user);
        void UpdateUser();
        void DeleteUser(int id);
    }
}
