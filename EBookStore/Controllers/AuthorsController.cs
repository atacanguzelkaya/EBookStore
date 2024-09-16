using Microsoft.AspNetCore.Mvc;
using EBookStore.Services.Abstracts;
using EBookStore.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace EBookStore.Controllers;
[Authorize(Roles = "Admin")]
public class AuthorsController : Controller
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _authorService.GetAllAuthors());
    }

    public async Task<IActionResult> Details(int id)
    {
        var author = await _authorService.GetAuthorById(id);
        if (author == null)
        {
            return NotFound();
        }
        return View(author);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FirstName,LastName")] AuthorDTO author)
    {
        if (ModelState.IsValid)
        {
            await _authorService.AddAuthor(author);
            return RedirectToAction(nameof(Index));
        }
        return View(author);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var author = await _authorService.GetAuthorById(id);
        if (author == null)
            return NotFound();
        var authorToUpdate = new AuthorDTO
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
        };
        return View(author);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Id")] AuthorDTO authorToUpdate)
    {
        if (id != authorToUpdate.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            await _authorService.UpdateAuthor(authorToUpdate);
            return RedirectToAction(nameof(Index));
        }
        return View(authorToUpdate);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var author = await _authorService.GetAuthorById(id);
        if (author == null) 
            return NotFound();
        return View(author);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _authorService.DeleteAuthor(id);
        return RedirectToAction(nameof(Index));
    }
}
