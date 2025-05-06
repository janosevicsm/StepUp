namespace Backend.Models;

public class Workout
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public required WorkoutType WorkoutType { get; set; }
    public required int Duration { get; set; }
    public required int Calories { get; set; }
    public required int Intensity { get; set; }
    public required int Fatigue { get; set; }
    public string? Notes { get; set; }
    public DateTime DateTime { get; set; }
    
}