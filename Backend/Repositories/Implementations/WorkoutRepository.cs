using Backend.Exceptions;
using Backend.Infrastructure.Context;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.Implementations;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly AppDbContext _context;

    public WorkoutRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Workout>> GetByUserIdAsync(int userId)
    {
        return await _context.Workouts
            .Where(w => w.UserId == userId)
            .ToListAsync();
    }
    
    public async Task<Workout?> AddAsync(Workout workout)
    {
        if (workout?.UserId == null) 
        {
            throw new EmptyFieldException("User id field can not be empty!");
        }
        
        if (workout.DateTime.Kind != DateTimeKind.Utc)
        {
            workout.DateTime = workout.DateTime.ToUniversalTime();
        }
        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync();
        return workout;
    }
}