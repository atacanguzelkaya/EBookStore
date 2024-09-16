using Microsoft.AspNetCore.Identity;

namespace EBookStore.Models;

public class ApplicationUser : IdentityUser
{
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Cart> Carts { get; set; }
}