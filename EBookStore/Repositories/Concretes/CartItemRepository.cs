using EBookStore.Data;
using EBookStore.Models;
using EBookStore.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace EBookStore.Repositories.Concretes;

public class CartItemRepository : EfRepositoryBase<CartItem>, ICartItemRepository
{ 
    public CartItemRepository(ApplicationDbContext context) : base(context) { }

}