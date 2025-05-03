namespace Backend.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public List<WorkoutDto> Workouts { get; set; } = new List<WorkoutDto>();
}