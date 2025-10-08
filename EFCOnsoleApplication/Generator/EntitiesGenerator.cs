using Microsoft.Extensions.Logging;
using Models.Abstraction;
using Models.Models;

namespace EFCOnsoleApplication.Generator
{
    public class EntitiesGenerator
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EntitiesGenerator> _logger;
        private readonly IRepository<Teacher> _teacherRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Course> _courseRepository;

        public EntitiesGenerator(
            IUnitOfWork unitOfWork,
            ILogger<EntitiesGenerator> logger,
            IRepository<Teacher> teacherRepository,
            IRepository<Student> studentRepository,
            IRepository<Course> courseRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task GenerateEntitiesAsync()
        {
            var existingTeachers = await _teacherRepository.GetAllAsync();
            var existingStudents = await _studentRepository.GetAllAsync();
            var existingCourses = await _courseRepository.GetAllAsync();

            if (existingTeachers.Any() || existingStudents.Any() || existingCourses.Any())
            {
                _logger.LogInformation("Database already seeded. Skipping initialization...");
                return;
            }

            _logger.LogInformation("Seeding initial data...");

            // Teachers
            var teachers = new List<Teacher>
            {
                new() { FirstName = "John", LastName = "Smith" },
                new() { FirstName = "Anna", LastName = "Brown" },
                new() { FirstName = "David", LastName = "Miller" }
            };

            foreach (var teacher in teachers)
                await _teacherRepository.AddAsync(teacher);

            // Students
            var students = new List<Student>
            {
                new() { FirstName = "Alice", LastName = "Johnson", Age = 20 },
                new() { FirstName = "Bob", LastName = "Williams", Age = 22 },
                new() { FirstName = "Charlie", LastName = "Davis", Age = 19 }
            };

            foreach (var student in students)
                await _studentRepository.AddAsync(student);

            await _unitOfWork.SaveChangesAsync();

            // Courses
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

            foreach (var course in courses)
                await _courseRepository.AddAsync(course);

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Initial data successfully seeded.");
        }
    }
}
