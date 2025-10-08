using ContextAndMigrations.Context;
using Microsoft.EntityFrameworkCore;
using Models.Abstraction;
using Models.Models;

namespace EFCOnsoleApplication.Repositories;

public class StudentRepository : IRepository<Student>
{
    private readonly CAContext _context;

    public StudentRepository(CAContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Student entity)
    {
        await _context.Students.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task Remove(int id)
    {
        await _context.Students.Where(s => s.Id == id).ExecuteDeleteAsync();
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}