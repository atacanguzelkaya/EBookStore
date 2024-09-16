using EBookStore.Data;
using EBookStore.Models;
using EBookStore.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace EBookStore.Repositories.Concretes;

public class OrderItemRepository : EfRepositoryBase<OrderItem>, IOrderItemRepository { 
    public OrderItemRepository(ApplicationDbContext context) : base(context) { }

}