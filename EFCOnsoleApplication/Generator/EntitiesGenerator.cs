using ContextAndMigrations.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Models;

namespace EFCOnsoleApplication.Generator;

public static class EntitiesGenerator
{
    public static void GenerateEntities(CAContext context, ILogger logger)
    {
        if (context.Teachers.Any() || context.Students.Any() || context.Courses.Any())
        {
            logger.LogInformation("Database already seeded");
            return;
        }

        logger.LogInformation("Seeding initial data...");

        var teachers = new List<Teacher>
        {
            new() { FirstName = "John", LastName = "Smith" },
            new() { FirstName = "Anna", LastName = "Brown" },
            new() { FirstName = "David", LastName = "Miller" }
        };

        var students = new List<Student>
        {
            new() { FirstName = "Alice", LastName = "Johnson", Age = 20 },
            new() { FirstName = "Bob", LastName = "Williams", Age = 22 },
            new() { FirstName = "Charlie", LastName = "Davis", Age = 19 }
        };

        context.Teachers.AddRange(teachers);
        context.Students.AddRange(students);
        context.SaveChanges();

        var courses = new List<Course>
        {
            new()
            {
                Name = "C# Fundamentals",
                TeacherId = teachers[0].Id,
                StudentId = students[0].Id
            },
            new()
            {
                Name = "ASP.NET Core Basics",
                TeacherId = teachers[1].Id,
                StudentId = students[1].Id
            },
            new()
            {
                Name = "Entity Framework Core Deep Dive",
                TeacherId = teachers[2].Id,
                StudentId = students[2].Id
            }
        };

        context.Courses.AddRange(courses);
        context.SaveChanges();

        logger.LogInformation("Initial data successfully seeded.");
    }
    
}