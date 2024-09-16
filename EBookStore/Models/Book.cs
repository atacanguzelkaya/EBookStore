namespace EBookStore.Models;

public class Book : BaseEntity
{
    public string Title { get; set; }
    public string ISBN { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
	public int PublisherId { get; set; }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
    public virtual Publisher Publisher { get; set; }
    public virtual Category Category { get; set; }
    public virtual Author Author { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; }
}