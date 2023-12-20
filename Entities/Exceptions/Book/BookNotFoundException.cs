using Entities.Exceptions.Base;

namespace Entities.Exceptions.Book;

public sealed class BookNotFoundException : NotFoundException
{
    public BookNotFoundException(int id) : base($"The book with id: {id} could not found.")
    {
    }
}


