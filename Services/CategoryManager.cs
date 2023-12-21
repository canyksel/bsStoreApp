using AutoMapper;
using Entities.DTOs;
using Entities.Exceptions.Category;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class CategoryManager : ICategoryService
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public CategoryManager(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<CategoryDto> CreateOneCategoryAsync(CategoryDto categoryDto)
    {
        var entity = _mapper.Map<Category>(categoryDto);

        _manager.Category.CreateOneCategory(entity);
        await _manager.SaveAsync();

        return _mapper.Map<CategoryDto>(entity);
    }

    public async Task DeleteOneCategoryAsync(int id, bool trackChanges)
    {
        var entity = await GetOneCategoryByIdAndCheckExists(id, trackChanges);
        
        _manager.Category.DeleteOneCategory(entity);
        await _manager.SaveAsync();
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
    {
        return await _manager
            .Category
            .GetAllCategoriesAsync(trackChanges);
    }

    public async Task<CategoryDto> GetOneCategoryByIdAsync(int id, bool trackChanges)
    {
        var category = await GetOneCategoryByIdAndCheckExists(id, trackChanges);

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task UpdateOneCategoryAsync(int id, CategoryDtoForUpdate categoryDto, bool trackChanges)
    {
        var entity = await GetOneCategoryByIdAndCheckExists(id, trackChanges);

        entity = _mapper.Map<Category>(categoryDto);

        _manager.Category.Update(entity);
        await _manager.SaveAsync();
    }

    private async Task<Category> GetOneCategoryByIdAndCheckExists(int id, bool trackChanges)
    {
        var entity = await _manager.Category.GetOneCategoryByIdAsync(id, trackChanges);

        if (entity is null) throw new CategoryNotFoundException(id);

        return entity;

    }
}
