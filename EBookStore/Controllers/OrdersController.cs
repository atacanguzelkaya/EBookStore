using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EBookStore.Data;
using Microsoft.AspNetCore.Authorization;
using EBookStore.Services.Abstracts;
using EBookStore.Services.Concretes;


namespace EBookStore.Controllers;
[Authorize(Roles = "Admin")]
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<IActionResult> Index()
    {
        var orders = await _orderService.GetAllOrders();
        return View(orders);
	}

	public async Task<IActionResult> Details(int id)
	{
		if (id == null) return NotFound();
		var order = await _orderService.GetOrderByIdWithItems(id);
		if (order == null) return NotFound();
		return View(order);
	}

	public async Task<IActionResult> Delete(int id)
    {
		if (id == null) return NotFound();
		var order = await _orderService.GetOrderById(id);
		if (order is null) return NotFound();
		return View(order);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
		await _orderService.DeleteOrder(id);
		return RedirectToAction(nameof(Index));
	}
}