using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IProgressService
{
    Dictionary<int, Progress> GroupWorkoutsByWeek(List<Workout> workouts);
    IEnumerable<int> GetAllWeeksInMonth(int year, int month);
    List<Progress> CreateWeeklyProgress(IEnumerable<int> allWeeks, Dictionary<int, Progress> groupedWorkouts);
}