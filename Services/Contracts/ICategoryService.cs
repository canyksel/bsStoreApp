﻿using Entities.DTOs;
using Entities.Models;

namespace Services.Contracts;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
    Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges);
    Task<Category> CreateOneCategoryAsync(CategoryDto category);
}
