using TaskFlowAPI.DTOs;
using TaskFlowAPI.Entities;
using TaskFlowAPI.Repositories;

namespace TaskFlowAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        public UserService(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
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
                HashedPassword = _passwordService.HashPassword(userDto.Password, out var salt),
                PasswordSalt = Convert.ToHexString(salt)
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
            user.HashedPassword = _passwordService.HashPassword(userDto.Password, out var salt);
            user.PasswordSalt = Convert.ToHexString(salt);

            _userRepository.UpdateUser();
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }
    }
}
