using EBookStore.Models;
namespace EBookStore.Repositories.Abstracts;

public interface IOrderRepository : IEfRepositoryBase<Order>
{
	Task AddOrderAsync(Order order);
	Task AddOrderItemAsync(OrderItem orderItem);
	Task<Order> GetOrderByIdWithItems(int id);
}