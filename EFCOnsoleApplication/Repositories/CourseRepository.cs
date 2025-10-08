using ContextAndMigrations.Context;
using Microsoft.EntityFrameworkCore;
using Models.Abstraction;
using Models.Models;

namespace EFCOnsoleApplication.Repositories;

public class CourseRepository : IRepository<Course>
{
    private readonly CAContext _context;
    public CourseRepository(CAContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _context.Courses.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Course entity)
    {
        await _context.Courses.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task Remove(int id)
    {
        await _context.Courses.Where(s => s.Id == id).ExecuteDeleteAsync();
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}