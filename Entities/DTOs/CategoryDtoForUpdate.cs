namespace Entities.DTOs;

public record CategoryDtoForUpdate
{
    public int CategoryId { get; init; }
    public int CategoryName { get; init; }
}
