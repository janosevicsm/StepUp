namespace Backend.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(string email, int userId);
}