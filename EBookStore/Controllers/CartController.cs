using EBookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using EBookStore.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;

namespace EBookStore.Controllers;

[Authorize]
public class CartController : Controller
{
	private readonly ICartService _cartService;

	public CartController(ICartService cartService)
	{
		_cartService = cartService;
	}

	public async Task<IActionResult> AddItem(int bookId, int quantity)
	{
		var cartCount = await _cartService.AddItemToCartAsync(bookId, quantity=1);
		return Ok(cartCount);
	}
    public async Task<IActionResult> DecreaseItem(int bookId)
    {
        var cartCount = await _cartService.DecreaseItemFromCartAsync(bookId);
        return Ok(cartCount);
    }

    public async Task<IActionResult> RemoveItem(int bookId)
	{
		var cartCount = await _cartService.RemoveItemFromCartAsync(bookId);
        return Ok(cartCount);
    }

	public async Task<IActionResult> GetUserCart()
	{
		var cart = await _cartService.GetCartByUserIdAsync();
		return View(cart);
	}
	public async Task<IActionResult> GetCartItemCount()
	{
		var cart = await _cartService.GetCartItemCountAsync();
		return Ok(cart);
	}

	public IActionResult Checkout()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Checkout(PaymentViewModel model)
	{
		if (!ModelState.IsValid)
			return View(model);

		bool success = await _cartService.CheckoutAsync(model);
		if (success)
			return RedirectToAction(nameof(OrderSuccess));

		return RedirectToAction(nameof(OrderFailure));
	}
    public IActionResult OrderSuccess()
    {
        return View();
    }
    public IActionResult OrderFailure()
    {
        return View();
    }
}