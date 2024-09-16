using EBookStore.Models;
using EBookStore.Models.DTOs;
using Humanizer.Localisation;

namespace EBookStore.Services.Abstracts;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category> GetCategoryById(int id);
    Task AddCategory(CategoryDTO category);
    Task UpdateCategory(CategoryDTO category);
    Task DeleteCategory(int id);
}