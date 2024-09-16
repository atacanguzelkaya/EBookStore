using EBookStore.Models;
using EBookStore.Models.DTOs;

namespace EBookStore.Services.Abstracts;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllBooks();
    Task<Book> GetBookById(int id);
    Task AddBook(BookDTO book);
    Task UpdateBook(BookDTO book);
    Task DeleteBook(int id);
    Task<IEnumerable<Book>> SearchBooks(string searchTerm);
}