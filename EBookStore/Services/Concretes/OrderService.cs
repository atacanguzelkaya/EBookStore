using EBookStore.Models;
using EBookStore.Services.Abstracts;
using EBookStore.Repositories.Concretes;
using EBookStore.Repositories.Abstracts;
using EBookStore.Models.ViewModels;
using AutoMapper;
using EBookStore.Models.DTOs;
using EBookStore.Services.ServiceRules;

namespace EBookStore.Services.Concretes;

public class OrderService : IOrderService
{
	private readonly IOrderRepository _orderRepository;
	private readonly OrderRules _orderRules;

	public OrderService(IOrderRepository orderRepository, OrderRules orderRules)
	{
		_orderRepository = orderRepository;
		_orderRules = orderRules;
	}

	public async Task<IEnumerable<Order>> GetAllOrders()
	{
		return await _orderRepository.GetAllAsync();
	}

	public async Task<Order> GetOrderById(int id)
	{
		var order = await _orderRepository.GetByIdAsync(id);
		await _orderRules.OrderNotFoundException(order);
		return order;
	}

	public async Task DeleteOrder(int id)
	{
		var order = await _orderRepository.GetByIdAsync(id);
		await _orderRules.OrderNotFoundException(order);
		await _orderRepository.DeleteAsync(order);
	}
	public async Task<Order> GetOrderByIdWithItems(int id)
	{
		var order = await _orderRepository.GetOrderByIdWithItems(id);
		await _orderRules.OrderNotFoundException(order);
		return order;
	}
}