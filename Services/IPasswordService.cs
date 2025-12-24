namespace TaskFlowAPI.Services
{
    public interface IPasswordService
    {
        string HashPassword(string password, out byte[] salt);

        bool IsPasswordVerified(string password, string hashedPassword, byte[] passwordSalt);
    }
}
