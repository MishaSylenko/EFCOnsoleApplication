using ContextAndMigrations.Context;
using EFCOnsoleApplication.Generator;
using EFCOnsoleApplication.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Models.Abstraction;
using Models.Models;

var services = new ServiceCollection();

services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Information);
});

var dbPath = Path.Combine(AppContext.BaseDirectory, "app.db");
services.AddDbContext<CAContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

services.AddScoped<IRepository<Student>, StudentRepository>();
services.AddScoped<IRepository<Course>, CourseRepository>();
services.AddScoped<IRepository<Teacher>, TeacherRepository>();
services.AddScoped<Commands>();

services.AddScoped<CAContext>();

var provider = services.BuildServiceProvider();

var db = provider.GetRequiredService<CAContext>();
var logger = provider.GetRequiredService<ILogger<Program>>();
var commands = provider.GetRequiredService<Commands>();


EntitiesGenerator.GenerateEntities(db, logger);

logger.LogInformation("Number of teachers in database: {Count}", db.Teachers.Count());

await commands.ListAllTeachersAsync();
await commands.ListAllStudentsAsync();
await commands.ListAllCoursesAsync();