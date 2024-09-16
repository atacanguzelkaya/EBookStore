using EBookStore.Data;
using EBookStore.Models;
using EBookStore.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace EBookStore.Repositories.Concretes;

public class CartRepository : EfRepositoryBase<Cart>, ICartRepository { 
    public CartRepository(ApplicationDbContext context) : base(context) { }
	public async Task<Cart> GetCartByUserIdAsync(string userId)
	{
		return await _context.Carts
			.Include(c => c.CartItems)
			.ThenInclude(ci => ci.Book)
			.FirstOrDefaultAsync(c => c.UserId == userId);
	}

	public async Task AddCartAsync(Cart cart)
	{
		await _context.Carts.AddAsync(cart);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateCartAsync(Cart cart)
	{
		_context.Carts.Update(cart);
		await _context.SaveChangesAsync();
	}

	public async Task ClearCartAsync(int cartId)
	{
		var cart = await _context.Carts
			.Include(c => c.CartItems)
			.FirstOrDefaultAsync(c => c.Id == cartId);

		if (cart != null)
		{
			_context.CartItems.RemoveRange(cart.CartItems);
			await _context.SaveChangesAsync();
		}
	}
}