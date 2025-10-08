using ContextAndMigrations.Context;
using EFCOnsoleApplication.Repositories;
using Microsoft.Extensions.Logging;
using Models.Abstraction;
using Models.Models;

namespace EFCOnsoleApplication.Generator;

public class Commands
{
    private readonly IRepository<Course> _courseRepository;
    private readonly IRepository<Student> _studentRepository;
    private readonly IRepository<Teacher> _teacherRepository;

    public Commands(
        IRepository<Course> courseRepository,
        IRepository<Student> studentRepository,
        IRepository<Teacher> teacherRepository)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
        _teacherRepository = teacherRepository;
    }

    public async Task ListAllTeachersAsync()
    {
        var teachers = await _teacherRepository.GetAllAsync();
        foreach (var teacher in teachers)
        {
            Console.WriteLine($"Teacher ID: {teacher.Id}, Name: {teacher.FirstName} {teacher.LastName}");
        }
    }


    public async Task ListAllCoursesAsync()
    {
        var courses = await _courseRepository.GetAllAsync();
        foreach (var course in courses)
        {
            Console.WriteLine($"Course ID: {course.Id}, Name: {course.Name}, Teacher ID: {course.TeacherId}, Student ID: {course.StudentId}");
        }
    }
    public async Task ListAllStudentsAsync()
    {
        var students = await _studentRepository.GetAllAsync();
        foreach (var student in students)
        {
            Console.WriteLine($"Student ID: {student.Id}, Name: {student.FirstName} {student.LastName}, Age: {student.Age}");
        }
    }
}