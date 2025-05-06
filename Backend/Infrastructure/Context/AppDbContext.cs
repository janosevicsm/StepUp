using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Workout> Workouts { get; set; }
}