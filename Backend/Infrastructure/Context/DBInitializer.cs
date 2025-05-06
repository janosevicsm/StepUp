using Backend.Models;

namespace Backend.Infrastructure.Context;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Users.Any())
        {
            var user = new User
            {
                Email = "marko@mail.com",
                FirstName = "Marko",
                LastName = "Janosevic",
                Password = "$2a$11$pNf4jRIpb6L/zGsriuHeV.eaDpGT0Wbwe07oaVdinhUCHcGIGV2Aq"
            };

            context.Users.Add(user);
            context.SaveChanges();

            var random = new Random();
            var workouts = new List<Workout>();
            var startDate = DateTime.Today.AddMonths(-3);

            for (int week = 0; week < 12; week++)
            {
                var weekStart = startDate.AddDays(week * 7);

                for (int i = 0; i < 3; i++)
                {
                    var workoutDate = weekStart.AddDays(i);
                    var workoutTime = workoutDate.AddHours(random.Next(6, 20)).AddMinutes(random.Next(0, 60));

                    workouts.Add(new Workout
                    {
                        UserId = user.Id,
                        WorkoutType = (WorkoutType)random.Next(0, 3),
                        Duration = random.Next(20, 90),
                        Calories = random.Next(150, 600),
                        Intensity = random.Next(1, 10),
                        Fatigue = random.Next(1, 10),
                        Notes = $"Auto-generated workout on {workoutDate:yyyy-MM-dd}",
                        DateTime = workoutTime
                    });
                }
            }

            context.Workouts.AddRange(workouts);
            context.SaveChanges();
        }
    }
}