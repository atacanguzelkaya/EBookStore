namespace EBookStore.Models.DTOs;

public class BookDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
	public string ISBN { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? Image { get; set; }
    public int PublisherId { get; set; }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
}