using ContextAndMigrations.Context;
using EFCOnsoleApplication.Generator;
using EFCOnsoleApplication.QueryExecution;
using EFCOnsoleApplication.Repositories;
using EFCOnsoleApplication.UnitOfWork;
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

services.AddScoped<IRepository<Student>, BaseRepository<Student>>();
services.AddScoped<IRepository<Course>, BaseRepository<Course>>();
services.AddScoped<IRepository<Teacher>, BaseRepository<Teacher>>();
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<IQueryExecutor, QueryExecutor>();
services.AddScoped<Commands>();

services.AddScoped<DbContext, CAContext>();

var provider = services.BuildServiceProvider();

var db = provider.GetRequiredService<CAContext>();
var logger = provider.GetRequiredService<ILogger<Program>>();
var commands = provider.GetRequiredService<Commands>();
var executor = provider.GetRequiredService<IQueryExecutor>();



EntitiesGenerator.GenerateEntities(db, logger);

logger.LogInformation("Number of teachers in database: {Count}", db.Teachers.Count());

await commands.ListAllTeachersAsync();
await commands.ListAllStudentsAsync();
await commands.ListAllCoursesAsync();

var adults = executor.ExecuteQuery<Student>(q => q.Where(s => s.Age >= 21));

logger.LogInformation("Students aged 21 or older:");
foreach (var student in adults)
    logger.LogInformation("Student ID: {Id}, Name: {FirstName} {LastName}, Age: {Age}",
        student.Id, student.FirstName, student.LastName, student.Age);