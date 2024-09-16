using EBookStore.Data;
using EBookStore.Models;
using EBookStore.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace EBookStore.Repositories.Concretes;

public class EfRepositoryBase<T> : IEfRepositoryBase<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext _context;

    public EfRepositoryBase(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        entity.UpdatedDate = DateTime.Now;
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        entity.DeletedDate = DateTime.Now;
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }
}