using EBookStore.Data;
using EBookStore.Models;
using EBookStore.Repositories.Abstracts;

namespace EBookStore.Repositories.Concretes;

public class CategoryRepository : EfRepositoryBase<Category>, ICategoryRepository { 
    public CategoryRepository(ApplicationDbContext context) : base(context) { } 
}