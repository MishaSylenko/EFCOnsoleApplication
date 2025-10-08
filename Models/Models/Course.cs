namespace Models.Models;

public class Course
{
    public int Id { get; init; }
    public int StudentId { get; init; }
    public int TeacherId { get; init; }
    public string Name { get; init; } = null!;

    public Student Student { get; init; } = null!;
    public Teacher Teacher { get; init; } = null!;
}