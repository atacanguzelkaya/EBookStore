using EBookStore.Models;
using EBookStore.Models.DTOs;

namespace EBookStore.Services.Abstracts;

public interface IPublisherService
{
    Task<IEnumerable<Publisher>> GetAllPublishers();
    Task<Publisher> GetPublisherById(int id);
    Task AddPublisher(PublisherDTO publisher);
    Task UpdatePublisher(PublisherDTO publisher);
    Task DeletePublisher(int id);
}