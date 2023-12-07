namespace Repositories.Contracts;

public interface IRepositoryManager
{
    IBookRepository Book { get; }
    ICategoryRepository Category { get; }
    Task SaveAsync();
}
