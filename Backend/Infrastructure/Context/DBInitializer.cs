using Backend.Models;

namespace Backend.Infrastructure.Context;


public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Users.Any())
        {
            context.Users.AddRange(new[]
            {
                new User
                {
                    Email = "john.doe@example.com", FirstName = "John", LastName = "Doe",
                    Password = "$2a$10$0.zpHGthXODIO2nOf0nOBuemPSs9itnlgrvNbv5dSu4N5lziD/NBW"
                },
                new User
                {
                    Email = "jane.doe@example.com", FirstName = "Jane", LastName = "Doe",
                    Password = "$2a$10$0.zpHGthXODIO2nOf0nOBuemPSs9itnlgrvNbv5dSu4N5lziD/NBW"
                }
            });
        }
        
        context.SaveChanges();
    }
}
