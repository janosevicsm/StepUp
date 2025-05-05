using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IWorkoutRepository
{
    Task<List<Workout>> GetByUserIdAsync(int userId);
    Task<Workout?> AddAsync(Workout workout);
    Task<List<Workout>> GetWorkoutsForMonth(int userId, int year, int month);
}