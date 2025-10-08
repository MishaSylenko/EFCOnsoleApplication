namespace Models.Abstraction;

public interface IQueryExecutor
{
    IQueryable<T> ExecuteQuery<T>(Func<IQueryable<T>, IQueryable<T>> query) where T : class;
}