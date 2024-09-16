namespace EBookStore.Models;

public class Publisher : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}