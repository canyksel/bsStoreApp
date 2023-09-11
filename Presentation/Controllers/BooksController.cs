using Entities.DTOs;
using Entities.Modals;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IServiceManager _manager;

    public BooksController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var books = _manager
            .BookService
            .GetAllBooks(false);

        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetBook([FromRoute(Name = "id")] int id)
    {
        var book = _manager
            .BookService
            .GetOneBookById(id, false);

        return Ok(book);
    }

    [HttpPost]
    public IActionResult CreateBook([FromBody] Book book)
    {

        if (book is null) return BadRequest();

        _manager.BookService.CreateOneBook(book);

        return StatusCode(201, book);
    }

    [HttpPut]
    public IActionResult UpdateBook([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
    {

        if (bookDto is null) return BadRequest(); //400

        _manager.BookService.UpdateOneBook(id, bookDto, true);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteBook([FromRoute(Name = "id")] int id)
    {
        _manager.BookService.DeleteOneBook(id, false);
        return NoContent();
    }

    [HttpPatch("{id:int}")]
    public IActionResult PartiallyUpdateBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> book)
    {

        // check entity
        var entity = _manager
            .BookService
            .GetOneBookById(id, true);

        book.ApplyTo(entity);
        _manager.BookService.UpdateOneBook(id, new BookDtoForUpdate(entity.Id, entity.Title, entity.Price), true);

        return NoContent(); // 204
    }
}

