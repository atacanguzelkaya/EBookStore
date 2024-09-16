using EBookStore.Data;
using EBookStore.Models;
using EBookStore.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace EBookStore.Repositories.Concretes;

public class BookRepository : EfRepositoryBase<Book>, IBookRepository
{ 
    public BookRepository(ApplicationDbContext context) : base(context) { }

	public async Task<IEnumerable<Book>> GetAllWithIncludes()
	{
		return await _context.Books
			.Include(b => b.Publisher)
			.Include(b => b.Category)
			.Include(b => b.Author)
			.ToListAsync();
	}

	public async Task<Book> GetBookByIdAsync(int id)
	{
		return await _context.Books
			.Include(b => b.Publisher)
			.Include(b => b.Category)
			.Include(b => b.Author)
			.FirstOrDefaultAsync(m => m.Id == id);
	}
}