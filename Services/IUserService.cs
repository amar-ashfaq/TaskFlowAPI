using TaskFlowAPI.DTOs;

namespace TaskFlowAPI.Services
{
    public interface IUserService
    {
        List<UserReadDto> GetUsers();
        UserReadDto GetUser(int id);
        UserReadDto GetUserByUsername(string username);
        UserReadDto CreateUser(UserCreateDto user);
        void UpdateUser(int id, UserUpdateDto user);
        void DeleteUser(int id);
    }
}
