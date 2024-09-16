using EBookStore.Middleware;
using EBookStore.Models;

namespace EBookStore.Services.ServiceRules;

public class OrderRules
{
	public Task OrderNotFoundException(Order order)
	{
		if (order is null)
			throw new ServiceException($"Order with id {order.Id} does not exist");
		return Task.CompletedTask;
	}
}