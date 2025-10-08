using Microsoft.EntityFrameworkCore;
using Models.Abstraction;

namespace EFCOnsoleApplication.QueryExecution;

public class QueryExecutor : IQueryExecutor
{
    private readonly DbContext _context;
    public QueryExecutor(DbContext context)
    {
        _context = context;
    }
    public IQueryable<T> ExecuteQuery<T>(Func<IQueryable<T>, IQueryable<T>> query) where T : class
    {
        var baseQuery = _context.Set<T>().AsQueryable();
        return query(baseQuery);
    }
}