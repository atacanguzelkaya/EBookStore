using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EBookStore.Data;
using EBookStore.Services.Abstracts;
using EBookStore.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EBookStore.Controllers
{
	public class BooksController : Controller
	{
		private readonly IBookService _bookService;
		private readonly ApplicationDbContext _context;

		public BooksController(IBookService bookService, ApplicationDbContext context)
		{
			_bookService = bookService;
			_context = context;
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Index(string searchTerm)
		{
			var books = await _bookService.SearchBooks(searchTerm);
			ViewData["SearchTerm"] = searchTerm;
			return View(books);
		}

		public async Task<IActionResult> Details(int id)
		{
			var book = await _bookService.GetBookById(id);
			if (book == null)
				return NotFound();
			return View(book);
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create()
		{
			await PopulateDropDownsAsync();
			return View();
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(BookDTO book)
		{
			if (ModelState.IsValid)
			{
				await _bookService.AddBook(book);
				return RedirectToAction(nameof(Index));
			}
			await PopulateDropDownsAsync();
			return View(book);
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id)
		{
			var book = await _bookService.GetBookById(id);
			if (book == null)
				return NotFound();
			await PopulateDropDownsAsync();
			return View(book);
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, BookDTO book)
		{
			if (id != book.Id)
				return NotFound();

			if (ModelState.IsValid)
			{
				await _bookService.UpdateBook(book);
				return RedirectToAction(nameof(Index));
			}
			await PopulateDropDownsAsync();
			return View(book);
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			var book = await _bookService.GetBookById(id);
			if (book == null)
				return NotFound();
			return View(book);
		}

		[Authorize(Roles = "Admin")]
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _bookService.DeleteBook(id);
			return RedirectToAction(nameof(Index));
		}

		private async Task PopulateDropDownsAsync()
		{
			var authors = await _context.Authors.Select(a => new AuthorDTO
			{
				Id = a.Id,
				FirstName = a.FirstName,
				LastName = a.LastName
			}).ToListAsync();
			ViewBag.Authors = new SelectList(authors, "Id", "FullName");
			ViewBag.Publishers = new SelectList(await _context.Publishers.ToListAsync(), "Id", "Name");
			ViewBag.Categories = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
		}
	}
}
