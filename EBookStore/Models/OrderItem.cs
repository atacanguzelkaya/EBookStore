﻿namespace EBookStore.Models;

public class OrderItem : BaseEntity
{
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
    public int BookId { get; set; }
    public virtual Book Book { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}