namespace TaskFlowAPI.Services
{
    public interface IPasswordService
    {
        string HashPassword(string password, out byte[] salt);
    }
}
