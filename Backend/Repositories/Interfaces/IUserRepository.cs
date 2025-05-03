using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> AddAsync(User user);
    Task<List<User>> GetAllAsync();
}