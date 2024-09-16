using EBookStore.Models;
using EBookStore.Models.ViewModels;

namespace EBookStore.Services.Abstracts;

public interface ICartService
{
	Task<Cart> GetCartByUserIdAsync();
	Task<int> AddItemToCartAsync(int bookId, int quantity);
	Task<int> DecreaseItemFromCartAsync(int bookId);
    Task<int> RemoveItemFromCartAsync(int bookId);
	Task<int> GetCartItemCountAsync();
	Task<bool> CheckoutAsync(PaymentViewModel model);
}