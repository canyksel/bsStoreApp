namespace Entities.Exceptions.Base;

public abstract partial class NotFoundException : Exception
{
    protected NotFoundException(string message) : base(message)
    {
    }
}

