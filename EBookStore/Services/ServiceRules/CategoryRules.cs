using EBookStore.Middleware;
using EBookStore.Models;

namespace EBookStore.Services.ServiceRules;

public class CategoryRules
{
	public Task CategoryNotFoundException(Category category)
	{
		if (category is null)
			throw new ServiceException($"Category with id {category.Id} does not exist");
		return Task.CompletedTask;
	}
}