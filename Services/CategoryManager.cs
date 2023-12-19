using AutoMapper;
using Entities.DTOs;
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

    public async Task<Category> CreateOneCategoryAsync(CategoryDto categoryDto)
    {
        var entity = _mapper.Map<Category>(categoryDto);

        _manager.Category.CreateOneCategory(entity);
        await _manager.SaveAsync();

        return _mapper.Map<Category>(entity);
    }

    public async Task DeleteOneCategoryAsync(int id, bool trackChanges)
    {
        var entity = await GetOneCategoryByIdAsync(id, trackChanges);
        
        _manager.Category.DeleteOneCategory(entity);
        await _manager.SaveAsync();
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
    {
        return await _manager
            .Category
            .GetAllCategoriesAsync(trackChanges);
    }

    public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
    {
        return await _manager
             .Category
             .GetOneCategoryByIdAsync(id, trackChanges);
    }

    public Task UpdateOneCategoryAsync(int id, CategoryDtoForUpdate categoryDto, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}
