namespace Entities.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = default!;

    //Ref : Collection navigation property

    public ICollection<Book> Books { get; set;}
}
