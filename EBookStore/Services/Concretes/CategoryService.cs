using EBookStore.Models;
using EBookStore.Repositories.Abstracts;
using EBookStore.Models.DTOs;
using EBookStore.Services.Abstracts;
using EBookStore.Services.ServiceRules;
using AutoMapper;

namespace EBookStore.Services.Concretes;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;
	private readonly CategoryRules _categoryRules;

	public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, CategoryRules categoryRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryRules = categoryRules;
    }

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        await _categoryRules.CategoryNotFoundException(category);
        return category;
    }

    public async Task AddCategory(CategoryDTO category)
    {
        var categoryToAdd = _mapper.Map<Category>(category);
		await _categoryRepository.AddAsync(categoryToAdd);
    }

    public async Task UpdateCategory(CategoryDTO category)
    {
        var categoryUpdated = await _categoryRepository.GetByIdAsync(category.Id);
		await _categoryRules.CategoryNotFoundException(categoryUpdated);
		_mapper.Map(category, categoryUpdated);
		await _categoryRepository.UpdateAsync(categoryUpdated);
    }

    public async Task DeleteCategory(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
		await _categoryRules.CategoryNotFoundException(category);
		await _categoryRepository.DeleteAsync(category);
    }
}