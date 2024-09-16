using EBookStore.Data;
using EBookStore.Models;
using EBookStore.Repositories.Abstracts;

namespace EBookStore.Repositories.Concretes;

public class PublisherRepository : EfRepositoryBase<Publisher>, IPublisherRepository { 
    public PublisherRepository(ApplicationDbContext context) : base(context) { } 
}