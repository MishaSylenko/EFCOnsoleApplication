namespace Models.Abstraction;

public interface IUnitOfWork
{
    Task<int> SaveAsync();
}