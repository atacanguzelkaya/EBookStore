namespace EBookStore.Models;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}