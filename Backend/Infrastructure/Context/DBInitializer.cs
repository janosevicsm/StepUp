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
                    Email = "marko@mail.com", FirstName = "Marko", LastName = "Janosevic",
                    Password = "$2a$11$pNf4jRIpb6L/zGsriuHeV.eaDpGT0Wbwe07oaVdinhUCHcGIGV2Aq"
                }
            });
        }
        
        context.SaveChanges();
    }
}
