﻿using Entities.DTOs;
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
    public IActionResult CreateBook([FromBody] BookDtoForInsertion bookDto)
    {

        if (bookDto is null) return BadRequest(); // 400

        if (!ModelState.IsValid) return UnprocessableEntity(ModelState);


        var book = _manager.BookService.CreateOneBook(bookDto);

        return StatusCode(201, book); // CreatedAtRoute()
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
    public IActionResult PartiallyUpdateBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<BookDto> bookPatch)
    {

        // check entity
        var bookDto = _manager
            .BookService
            .GetOneBookById(id, true);

        bookPatch.ApplyTo(bookDto);
        _manager.BookService.UpdateOneBook(id, new BookDtoForUpdate() { Id = bookDto.Id, Title = bookDto.Title, Price = bookDto.Price }, true);

        return NoContent(); // 204
    }
}

