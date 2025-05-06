using Backend.Exceptions;
using Backend.Infrastructure.Context;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _context.Users
            .Include(u => u.Workouts)
            .FirstOrDefaultAsync(u => u.Id == id);
        if (user == null) 
        {
            throw new ResourceNotFoundException("User with that id does not exist!");
        }
        return user;
    }
    
    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            throw new ResourceNotFoundException("User with that email does not exist!");
        }
        return user;
    }
    
    private async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }
    
    public async Task<User?> AddAsync(User user)
    {
        bool existWithEmail = await ExistsByEmailAsync(user.Email);
        if (existWithEmail) 
        {
            throw new UserExistsException($"User with email: {user.Email} already exists!");
        }
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
    
    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }
}