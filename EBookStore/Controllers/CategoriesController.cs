using EBookStore.Models.DTOs;
using EBookStore.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles ="Admin")]
public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetAllCategories();
        return View(categories);
    }

    public async Task<IActionResult> Details(int id)
    {
        var category = await _categoryService.GetCategoryById(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name")] CategoryDTO category)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var category = await _categoryService.GetCategoryById(id);
        if (category == null) return NotFound();
        var categoryToUpdate = new CategoryDTO
        {
            Id = category.Id,
            Name = category.Name
        };
        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CategoryDTO categoryToUpdate)
    {
        if (id != categoryToUpdate.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _categoryService.UpdateCategory(categoryToUpdate);
            return RedirectToAction(nameof(Index));
        }
        return View(categoryToUpdate);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var category = await _categoryService.GetCategoryById(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _categoryService.DeleteCategory(id);
        return RedirectToAction(nameof(Index));
    }
}