namespace Models.Models;

public class Student
{
    public int Id { get; init; }
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public int Age { get; init; }
    
    public List<Course> Courses { get; init; } = new(); 
    public List<Teacher> Teachers { get; init; } = new();
}   