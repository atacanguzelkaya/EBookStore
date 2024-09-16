namespace EBookStore.Models;

public class Cart : BaseEntity
{
    public string UserId { get; set; }
	public virtual ApplicationUser User { get; set; }
	public virtual ICollection<CartItem> CartItems { get; set; }
}