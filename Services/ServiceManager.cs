using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger)
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager,logger));
        }
        public IBookService BookService => _bookService.Value;
    }
}
