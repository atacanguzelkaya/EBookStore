using EBookStore.Models;
using Microsoft.EntityFrameworkCore.Storage;
namespace EBookStore.Repositories.Abstracts;

public interface IBookRepository : IEfRepositoryBase<Book> 
{
	Task<IEnumerable<Book>> GetAllWithIncludes();
	Task<Book> GetBookByIdAsync(int id);
}