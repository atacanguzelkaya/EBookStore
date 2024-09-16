using EBookStore.Models;
using EBookStore.Models.DTOs;
using EBookStore.Repositories.Abstracts;
using EBookStore.Services.Abstracts;

namespace EBookStore.Services.Concretes;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;

    public PublisherService(IPublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }

    public async Task<IEnumerable<Publisher>> GetAllPublishers()
    {
        return await _publisherRepository.GetAllAsync();
    }

    public async Task<Publisher> GetPublisherById(int id)
    {
        var publisher = await _publisherRepository.GetByIdAsync(id);
        if (publisher == null) throw new InvalidOperationException($"Publisher with id {id} does not exist");
        return new Publisher
        {
            Id = publisher.Id,
            Name = publisher.Name
        };
    }

    public async Task AddPublisher(PublisherDTO publisher)
    {
        var publisherToAdd = new Publisher { Name = publisher.Name };
        await _publisherRepository.AddAsync(publisherToAdd);
    }

    public async Task UpdatePublisher(PublisherDTO publisher)
    {
        var publisherUpdated = await _publisherRepository.GetByIdAsync(publisher.Id);
        publisherUpdated.Name = publisher.Name;
        await _publisherRepository.UpdateAsync(publisherUpdated);
    }

    public async Task DeletePublisher(int id)
    {
        var publisher = await _publisherRepository.GetByIdAsync(id);
        if (publisher == null) throw new InvalidOperationException($"Publisher with id {id} does not exist");
        await _publisherRepository.DeleteAsync(publisher);
    }
}