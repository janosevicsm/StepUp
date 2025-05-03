using Backend.Models;

namespace Backend.DTOs;

public class WorkoutDto
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public WorkoutType? WorkoutType { get; set; }
    public int Duration { get; set; } 
    public int Calories { get; set; }
    public int Intensity { get; set; } 
    public int Fatigue { get; set; } 
    public string? Notes { get; set; }
    public DateTime DateTime { get; set; }
}