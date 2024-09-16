using EBookStore.Data;
using EBookStore.Models;
using EBookStore.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace EBookStore.Repositories.Concretes;

public class OrderRepository : EfRepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
    }
	public async Task AddOrderAsync(Order order)
	{
		await _context.Orders.AddAsync(order);
		await _context.SaveChangesAsync();
	}

	public async Task AddOrderItemAsync(OrderItem orderItem)
	{
		await _context.OrderItems.AddAsync(orderItem);
		await _context.SaveChangesAsync();
	}
	public async Task<Order> GetOrderByIdWithItems(int id)
	{
		return await _context.Orders
			.Include(o => o.OrderItems)
			.ThenInclude(oi => oi.Book)
			.FirstOrDefaultAsync(o => o.Id == id);
	}
}