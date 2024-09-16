namespace EBookStore.Models;

public class Order : BaseEntity
{
    public string UserId { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public string MobileNumber { get; set; }
	public string Address { get; set; }
	public string PaymentMethod { get; set; }
	public bool IsPaid { get; set; }

	public virtual ICollection<OrderItem> OrderItems { get; set; }
}