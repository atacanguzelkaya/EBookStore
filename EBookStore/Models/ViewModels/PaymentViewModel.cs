using System.ComponentModel.DataAnnotations;

namespace EBookStore.Models.ViewModels;

public class PaymentViewModel
{
	public string Name { get; set; }
	public string Email { get; set; }
	public string MobileNumber { get; set; }
	public string Address { get; set; }
	public string PaymentMethod { get; set; }
}
