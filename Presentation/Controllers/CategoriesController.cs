using Entities.DTOs;
using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly IServiceManager _manager;

    public CategoriesController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategoriesAsync()
    {
        return Ok(await _manager
            .CategoryService
            .GetAllCategoriesAsync(false));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategoryByIdAsync([FromRoute] int id)
    {
        var category = await _manager
             .CategoryService
             .GetOneCategoryByIdAsync(id, false);

        if (category is null) throw new CategoryNotFoundException(id);

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOneBookAsync([FromBody] CategoryDto categoryDto)
    {
        var category = await _manager.CategoryService.CreateOneCategoryAsync(categoryDto);

        return StatusCode(201, category);
    }
}
