using ContextAndMigrations.Configurations;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace ContextAndMigrations.Context;

public class CAContext : DbContext
{
    public CAContext(DbContextOptions<CAContext> options): base(options)
    {
        
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        
        modelBuilder.Entity<Student>()
            .HasMany(e => e.Teachers)
            .WithMany(c => c.Students)
            .UsingEntity<Course>();
    }
}