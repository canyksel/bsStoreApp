using Entities.Exceptions.Base;

namespace Entities.Exceptions.Book;


public class PriceOutofRangeBadRequestException : BadRequestException
{
    public PriceOutofRangeBadRequestException() : base("Maximum price should be less than 1000 and greater than 10.")
    {
    }
}

