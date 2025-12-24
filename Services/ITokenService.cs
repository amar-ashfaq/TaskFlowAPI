using TaskFlowAPI.DTOs;

namespace TaskFlowAPI.Services
{
    public interface ITokenService
    {
        string GenerateJwtToken(UserReadDto user);
    }
}
