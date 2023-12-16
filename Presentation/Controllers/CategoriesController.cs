using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly IServiceManager _services;

    public CategoriesController(IServiceManager services)
    {
        _services = services;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategoriesAsync()
    {
        return Ok(await _services
            .CategoryService
            .GetAllCategoriesAsync(false));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategoryByIdAsync([FromRoute] int id)
    {
        var category = await _services
             .CategoryService
             .GetOneCategoryByIdAsync(id, false);

        if (category is null) throw new CategoryNotFoundException(id);

        return Ok(category);
    }
}
