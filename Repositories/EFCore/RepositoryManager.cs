using Repositories.Contracts;

namespace Repositories.EFCore;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly Lazy<IBookRepository> _bookRepository;
    private readonly Lazy<ICategoryRepository> _categoryRepository;

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));
        _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
    }

    public IBookRepository Book => _bookRepository.Value;
    public ICategoryRepository Category => _categoryRepository.Value;

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
