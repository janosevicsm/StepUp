namespace Backend.Routes;

public static class WorkoutRoutes
{
    public const string Base = "api/workout";
    public const string GetWorkoutsByUser = "{userId}";
    public const string AddWorkout = "add";
    public const string GetProgress = "progress/{userId}";
}