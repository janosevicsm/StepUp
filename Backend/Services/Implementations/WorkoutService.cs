using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services.Implementations;

public class WorkoutService : IWorkoutService
{
    public readonly IWorkoutRepository _workoutRepository;
    public WorkoutService(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }
    
    public async Task<List<Workout>> GetWorkoutByUserIdAsync(int userId)
    {
        return await _workoutRepository.GetByUserIdAsync(userId);
    }
    
    public async Task<Workout?> AddWorkoutAsync(Workout workout)
    {
        return await _workoutRepository.AddAsync(workout);
    }
}