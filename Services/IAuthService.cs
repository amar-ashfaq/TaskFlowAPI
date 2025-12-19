using TaskFlowAPI.Entities;

namespace TaskFlowAPI.Services
{
    public interface IAuthService
    {
        void Login(User user);
        string GenerateJwtToken(string username);
    }
}
