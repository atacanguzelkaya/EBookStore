using EBookStore.Models;

namespace EBookStore.Services.Abstracts;

public interface IOrderService
{
	Task<IEnumerable<Order>> GetAllOrders();
	Task<Order> GetOrderById(int id);
	Task DeleteOrder(int id);
	Task<Order> GetOrderByIdWithItems(int id);
}