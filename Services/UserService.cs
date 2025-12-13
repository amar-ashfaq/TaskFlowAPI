using TaskFlowAPI.DTOs;
using TaskFlowAPI.Entities;
using TaskFlowAPI.Repositories;

namespace TaskFlowAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserReadDto> GetUsers()
        {
            var users = _userRepository.GetUsers()
                .Select(x => new UserReadDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Username = x.Username,
                    HashedPassword = x.HashedPassword,
                    PasswordSalt = x.PasswordSalt
                })
                .ToList();

            return users;
        }
        public UserReadDto GetUser(int id)
        {
            var user = _userRepository.GetUser(id);

            return new UserReadDto
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                HashedPassword = user.HashedPassword,
                PasswordSalt = user.PasswordSalt
            };
        }

        public UserReadDto GetUserByUsername(string username)
        {
            var user = _userRepository.GetUserByUsername(username);

            return new UserReadDto
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                HashedPassword = user.HashedPassword,
                PasswordSalt = user.PasswordSalt
            };
        }

        public UserReadDto CreateUser(UserCreateDto userDto)
        {
            ArgumentNullException.ThrowIfNull(userDto);

            var user = new User
            {
                Name = userDto.Name,
                Username = userDto.Username,
                HashedPassword = userDto.HashedPassword,
                PasswordSalt = ""
            };

            _userRepository.CreateUser(user);

            return new UserReadDto
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                HashedPassword = user.HashedPassword,
                PasswordSalt = user.PasswordSalt
            };
        }

        public void UpdateUser(int id, UserUpdateDto userDto)
        {
            ArgumentNullException.ThrowIfNull(userDto);

            var user = _userRepository.GetUser(id);

            user.Name = userDto.Name;
            user.Username = userDto.Username;
            user.HashedPassword = userDto.HashedPassword;

            _userRepository.UpdateUser();
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }
    }
}
