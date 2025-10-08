namespace Models.Models;

public class Teacher
{
    public int Id { get; init; }
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;

    public List<Course> Courses { get; init; } = new();

    public List<Student> Students { get; init; } = new();
}