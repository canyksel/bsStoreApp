using Services.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly IBookService _bookService;
    private readonly ICategoryService _categoryService;
    private readonly IAuthenticationService _authenticationService;

    public ServiceManager(IBookService bookService, ICategoryService categoryService, IAuthenticationService authenticationService)
    {
        _bookService = bookService;
        _categoryService = categoryService;
        _authenticationService = authenticationService;
    }

    public IBookService BookService => _bookService;

    public IAuthenticationService AuthenticationService => _authenticationService;

    public ICategoryService CategoryService => _categoryService;
}