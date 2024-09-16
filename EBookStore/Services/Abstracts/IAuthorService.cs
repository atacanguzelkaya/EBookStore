using EBookStore.Models;
using EBookStore.Models.DTOs;

namespace EBookStore.Services.Abstracts;

public interface IAuthorService
{
    Task<IEnumerable<Author>> GetAllAuthors();
    Task<Author> GetAuthorById(int id);
    Task AddAuthor(AuthorDTO author);
    Task UpdateAuthor(AuthorDTO author);
    Task DeleteAuthor(int id);
}