using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IUserService
{
    Task<User?> GetUserByIdAsync(int id);
    // Task<User?> GetUserByEmailAsync(string email);
    Task<User?> AddUserAsync(User user);
    // Task<User?> UpdateUserAsync(User user);
    Task<List<User>> GetAllUsersAsync();
    Task<User?> LoginUserAsync(string email, string password);
}