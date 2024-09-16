using EBookStore.Middleware;
using EBookStore.Models;

namespace EBookStore.Services.ServiceRules;

public class AuthorRules
{
	public Task AuthorNotFoundException(Author author)
	{
		if (author is null)
			throw new ServiceException($"Author with id {author.Id} does not exist");
		return Task.CompletedTask;
	}
}