using Entities.Exceptions.Base;

namespace Entities.Exceptions.Category;

public sealed class CategoryNotFoundException : NotFoundException
{
    public CategoryNotFoundException(int id) : base($"The category with id: {id} could not found.")
    {
    }
}
