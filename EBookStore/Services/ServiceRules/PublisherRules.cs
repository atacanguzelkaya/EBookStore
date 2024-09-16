using EBookStore.Middleware;
using EBookStore.Models;

namespace EBookStore.Services.ServiceRules;

public class PublisherRules
{
	public Task PublisherNotFoundException(Publisher publisher)
	{
		if (publisher is null)
			throw new ServiceException($"Publisher with id {publisher.Id} does not exist");
		return Task.CompletedTask;
	}
}