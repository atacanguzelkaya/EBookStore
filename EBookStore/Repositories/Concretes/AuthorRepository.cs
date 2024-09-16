using EBookStore.Data;
using EBookStore.Models;
using EBookStore.Repositories.Abstracts;

namespace EBookStore.Repositories.Concretes;

public class AuthorRepository : EfRepositoryBase<Author>, IAuthorRepository
{ 
    public AuthorRepository(ApplicationDbContext context) : base(context) { } 
}