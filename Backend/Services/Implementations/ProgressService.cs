using System.Globalization;
using Backend.Models;
using Backend.Services.Interfaces;

namespace Backend.Services.Implementations;

public class ProgressService : IProgressService
{
    public Dictionary<int, Progress> GroupWorkoutsByWeek(List<Workout> workouts)
    {
        return workouts
            .GroupBy(w => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                w.DateTime,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday))
            .ToDictionary(
                g => g.Key,
                g => new Progress
                {
                    Week = g.Key,
                    TotalDuration = g.Sum(w => w.Duration),
                    WorkoutCount = g.Count(),
                    AverageIntensity = g.Average(w => w.Intensity),
                    AverageFatigue = g.Average(w => w.Fatigue)
                });
    }

    public IEnumerable<int> GetAllWeeksInMonth(int year, int month)
    {
        var firstDayOfMonth = new DateTime(year, month, 1);
        var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

        return Enumerable
            .Range(0, (lastDayOfMonth - firstDayOfMonth).Days + 1)
            .Select(d => firstDayOfMonth.AddDays(d))
            .Select(date => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                date,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday))
            .Distinct();
    }
    
    public List<Progress> CreateWeeklyProgress(IEnumerable<int> allWeeks, Dictionary<int, Progress> groupedWorkouts)
    {
        return allWeeks
            .Select(week => groupedWorkouts.ContainsKey(week)
                ? groupedWorkouts[week]
                : new Progress
                {
                    Week = week,
                    TotalDuration = 0,
                    WorkoutCount = 0,
                    AverageIntensity = 0,
                    AverageFatigue = 0
                })
            .OrderBy(p => p.Week)
            .ToList();
    }
}