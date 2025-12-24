using TaskFlowAPI.DTOs;
using TaskFlowAPI.Entities;

namespace TaskFlowAPI.Services
{
    public interface IAuthService
    {
        User Register(User user);
        string Login(LoginRequestDto user);
    }
}
