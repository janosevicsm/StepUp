using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services.Implementations;

public class WorkoutService : IWorkoutService
{
    public readonly IWorkoutRepository _workoutRepository;
    public readonly IProgressService _progressService;
    public WorkoutService(IWorkoutRepository workoutRepository, IProgressService progressService)
    {
        _workoutRepository = workoutRepository;
        _progressService = progressService;
    }
    
    public async Task<List<Workout>> GetWorkoutByUserIdAsync(int userId)
    {
        return await _workoutRepository.GetByUserIdAsync(userId);
    }
    
    public async Task<Workout?> AddWorkoutAsync(Workout workout)
    {
        return await _workoutRepository.AddAsync(workout);
    }

    public async Task<List<Progress>> GetProgressAsync(int userId, int year, int month)
    {
        var workouts = await _workoutRepository.GetWorkoutsForMonth(userId, year, month);
        var allWeeks = _progressService.GetAllWeeksInMonth(year, month);
        var grouped = _progressService.GroupWorkoutsByWeek(workouts);
        return _progressService.CreateWeeklyProgress(allWeeks, grouped);
    }


}