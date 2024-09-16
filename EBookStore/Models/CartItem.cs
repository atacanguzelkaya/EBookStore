namespace EBookStore.Models;

public class CartItem : BaseEntity
{
    public int CartId { get; set; }
    public int BookId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

	public virtual Cart Cart { get; set; }
	public virtual Book Book { get; set; }
}