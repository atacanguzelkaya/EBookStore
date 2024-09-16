using EBookStore.Models;

namespace EBookStore.Repositories.Abstracts;

public interface IEfRepositoryBase<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}