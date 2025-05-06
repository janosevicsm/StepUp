namespace Backend.Models;

public class Progress
{
    public int Week { get; set; }
    public int TotalDuration { get; set; }
    public int WorkoutCount { get; set; }
    public double AverageIntensity { get; set; }
    public double AverageFatigue { get; set; }
}