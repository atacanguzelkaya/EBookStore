using EBookStore.Models;
namespace EBookStore.Repositories.Abstracts;

public interface ICartRepository : IEfRepositoryBase<Cart> 
{
	Task<Cart> GetCartByUserIdAsync(string userId);
	Task AddCartAsync(Cart cart);
	Task UpdateCartAsync(Cart cart);
	Task ClearCartAsync(int cartId);
}