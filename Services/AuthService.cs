using TaskFlowAPI.DTOs;
using TaskFlowAPI.Entities;

namespace TaskFlowAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public AuthService(ITokenService tokenService, IUserService userService, IPasswordService passwordService)
        {
            _tokenService = tokenService;
            _userService = userService;
            _passwordService = passwordService;
        }

        public User Register(User user) // we already do a register user in UserService - do we even need this here?
        {
            return null;
        }

        public string Login(LoginRequestDto userDto)
        {
            ArgumentNullException.ThrowIfNull(userDto);

            var user = _userService.GetUserByUsername(userDto.Username);

            var passwordSalt = Convert.FromHexString(user.PasswordSalt);

            bool verified = _passwordService.IsPasswordVerified(userDto.Password, user.HashedPassword, passwordSalt);

            if (!verified) 
            {
                throw new UnauthorizedAccessException("Invalid password entered.");
            }

            return _tokenService.GenerateJwtToken(user);
        }
    }
}
