using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IWorkoutService
{
    Task<List<Workout>> GetWorkoutByUserIdAsync(int userId);
    Task<Workout?> AddWorkoutAsync(Workout workout);
}