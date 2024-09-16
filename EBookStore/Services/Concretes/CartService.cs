using EBookStore.Data;
using EBookStore.Models;
using EBookStore.Models.ViewModels;
using EBookStore.Repositories.Abstracts;
using EBookStore.Services.Abstracts;

namespace EBookStore.Services.Concretes;

public class CartService : ICartService
{
	private readonly ICartRepository _cartRepository;
	private readonly IOrderRepository _orderRepository;
	private readonly IUserService _userService;
	private readonly IBookRepository _bookRepository;

	public CartService(ICartRepository cartRepository, IOrderRepository orderRepository,
					   IUserService userService, IBookRepository bookRepository)
	{
		_cartRepository = cartRepository;
		_orderRepository = orderRepository;
		_userService = userService;
		_bookRepository = bookRepository;
	}

	public async Task<Cart> GetCartByUserIdAsync()
	{
		var userId = await _userService.GetUserIdAsync();
		return await _cartRepository.GetCartByUserIdAsync(userId);
	}

	public async Task<int> AddItemToCartAsync(int bookId, int quantity)
	{
		var userId = await _userService.GetUserIdAsync();
		var cart = await _cartRepository.GetCartByUserIdAsync(userId);

		if (cart == null)
		{
			cart = new Cart { UserId = userId };
			await _cartRepository.AddCartAsync(cart);
		}

		var cartItem = cart.CartItems.FirstOrDefault(ci => ci.BookId == bookId);
		if (cartItem != null)
		{
			cartItem.Quantity += quantity;
		}
		else
		{
			var book = await _bookRepository.GetByIdAsync(bookId);
			cart.CartItems.Add(new CartItem
			{
				BookId = bookId,
				CartId = cart.Id,
				Quantity = quantity,
				UnitPrice = book.Price
			});
		}

		await _cartRepository.UpdateCartAsync(cart);
		return cart.CartItems.Sum(ci => ci.Quantity);
	}

    public async Task<int> DecreaseItemFromCartAsync(int bookId)
    {
        var userId = await _userService.GetUserIdAsync();
        var cart = await _cartRepository.GetCartByUserIdAsync(userId);

        var cartItem = cart.CartItems.FirstOrDefault(ci => ci.BookId == bookId);
        if (cartItem.Quantity == 1)
        {
            cart.CartItems.Remove(cartItem);
            await _cartRepository.UpdateCartAsync(cart);
        }
        else
        {
            cartItem.Quantity = cartItem.Quantity - 1;
            await _cartRepository.UpdateCartAsync(cart);
        }
		return cartItem.Quantity;
    }

    public async Task<int> RemoveItemFromCartAsync(int bookId)
	{
		var userId = await _userService.GetUserIdAsync();
		var cart = await _cartRepository.GetCartByUserIdAsync(userId);

		var cartItem = cart.CartItems.FirstOrDefault(ci => ci.BookId == bookId);
		if (cartItem != null)
		{
			cart.CartItems.Remove(cartItem);
			await _cartRepository.UpdateCartAsync(cart);
		}

		return cart.CartItems.Sum(ci => ci.Quantity);
	}

	public async Task<int> GetCartItemCountAsync()
	{
		var userId = await _userService.GetUserIdAsync();
		var cart = await _cartRepository.GetCartByUserIdAsync(userId);
		return cart?.CartItems.Sum(ci => ci.Quantity) ?? 0;
	}

	public async Task<bool> CheckoutAsync(PaymentViewModel model)
	{
		var userId = await _userService.GetUserIdAsync();
		var cart = await _cartRepository.GetCartByUserIdAsync(userId);

		if (cart == null || !cart.CartItems.Any())
			return false;

		var order = new Order
		{
			UserId = userId,
			Name = model.Name,
			Email = model.Email,
			MobileNumber = model.MobileNumber,
			PaymentMethod = model.PaymentMethod,
			Address = model.Address,
			IsPaid = true
		};	

		await _orderRepository.AddOrderAsync(order);

		foreach (var cartItem in cart.CartItems)
		{
			var book = await _bookRepository.GetByIdAsync(cartItem.BookId);
			if (book.Stock < cartItem.Quantity)
				throw new InvalidOperationException("Not enough stock.");

			book.Stock -= cartItem.Quantity;

			var orderItem = new OrderItem
			{
				OrderId = order.Id,
				BookId = cartItem.BookId,
				Quantity = cartItem.Quantity,
				UnitPrice = cartItem.UnitPrice
			};

			await _orderRepository.AddOrderItemAsync(orderItem);
		}

		await _cartRepository.ClearCartAsync(cart.Id);
		return true;
	}
}