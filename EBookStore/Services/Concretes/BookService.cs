using AutoMapper;
using EBookStore.Models.DTOs;
using EBookStore.Models;
using EBookStore.Repositories.Abstracts;
using EBookStore.Services.Abstracts;
using EBookStore.Services.ServiceRules;

public class BookService : IBookService
{
	private readonly IBookRepository _bookRepository;
	private readonly IMapper _mapper;
	private readonly BookRules _bookRules;

	public BookService(IBookRepository bookRepository, IMapper mapper, BookRules bookRules)
	{
		_bookRepository = bookRepository;
		_mapper = mapper;
		_bookRules = bookRules;
	}

	public async Task<IEnumerable<Book>> GetAllBooks()
	{
		var books = await _bookRepository.GetAllWithIncludes();
		return books;
	}

	public async Task<IEnumerable<Book>> SearchBooks(string searchTerm)
	{
		if (string.IsNullOrWhiteSpace(searchTerm))
			return await _bookRepository.GetAllWithIncludes();

		var books = await _bookRepository.GetAllWithIncludes();
		searchTerm = searchTerm.Trim();

		return books.Where(b =>
			b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
			b.Author.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
			b.Author.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
			b.Category.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
			b.Publisher.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
		);
	}

	public async Task<Book> GetBookById(int id)
	{
		var book = await _bookRepository.GetBookByIdAsync(id);
		await _bookRules.BookNotFoundException(book);
		return book;
	}

	public async Task AddBook(BookDTO book)
	{
		var bookToAdd = _mapper.Map<Book>(book);
		await _bookRepository.AddAsync(bookToAdd);
	}

	public async Task UpdateBook(BookDTO book)
	{
		var bookUpdated = await _bookRepository.GetByIdAsync(book.Id);
		await _bookRules.BookNotFoundException(bookUpdated);
		_mapper.Map(book, bookUpdated);
		await _bookRepository.UpdateAsync(bookUpdated);
	}

	public async Task DeleteBook(int id)
	{
		var book = await _bookRepository.GetBookByIdAsync(id);
		await _bookRules.BookNotFoundException(book);
		await _bookRepository.DeleteAsync(book);
	}
}