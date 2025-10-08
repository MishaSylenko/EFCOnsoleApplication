using Microsoft.EntityFrameworkCore;
using Models.Abstraction;

namespace EFCOnsoleApplication.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private DbContext _context;
    
    public UnitOfWork(DbContext context)
    {
        _context = context;
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}