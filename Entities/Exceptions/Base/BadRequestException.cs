namespace Entities.Exceptions.Base;

public abstract partial class BadRequestException : Exception
{
    protected BadRequestException(string message) : base(message) { }
}
