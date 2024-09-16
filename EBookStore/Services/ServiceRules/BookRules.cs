using EBookStore.Middleware;
using EBookStore.Models;

namespace EBookStore.Services.ServiceRules;

public class BookRules
{
	public Task BookNotFoundException(Book book)
	{
		if (book is null)
			throw new ServiceException($"Book with id {book.Id} does not exist");
		return Task.CompletedTask;
	}
}