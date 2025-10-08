using ContextAndMigrations.Context;
using Microsoft.EntityFrameworkCore;
using Models.Abstraction;
using Models.Models;

namespace EFCOnsoleApplication.Repositories;

public class TeacherRepository : IRepository<Teacher>
{
    private readonly CAContext _context;
    public TeacherRepository(CAContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Teacher>> GetAllAsync()
    {
        return await _context.Teachers.ToListAsync();
    }

    public async Task<Teacher?> GetByIdAsync(int id)
    {
        return await _context.Teachers.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Teacher entity)
    {
        await _context.Teachers.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task Remove(int id)
    {
        await _context.Teachers.Where(s => s.Id == id).ExecuteDeleteAsync();
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}