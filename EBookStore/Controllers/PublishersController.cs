using Microsoft.AspNetCore.Mvc;
using EBookStore.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using EBookStore.Services.Abstracts;

namespace EBookStore.Controllers;

[Authorize(Roles = "Admin")]
public class PublishersController : Controller
{
    private readonly IPublisherService _publisherService;

    public PublishersController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    public async Task<IActionResult> Index()
    {
        var publishers = await _publisherService.GetAllPublishers();
        return View(publishers);
    }

    public async Task<IActionResult> Details(int id)
    {
        var publisher = await _publisherService.GetPublisherById(id);
        if (publisher == null)
        {
            return NotFound();
        }
        return View(publisher);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PublisherDTO publisher)
    {
        if (ModelState.IsValid)
        {
            await _publisherService.AddPublisher(publisher);
            return RedirectToAction(nameof(Index));
        }
        return View(publisher);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var publisher = await _publisherService.GetPublisherById(id);
        if (publisher == null) return NotFound();
        var publisherToUpdate = new PublisherDTO
        {
            Id = publisher.Id,
            Name = publisher.Name
        };
        return View(publisher);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, PublisherDTO publisherToUpdate)
    {
        if (id != publisherToUpdate.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _publisherService.UpdatePublisher(publisherToUpdate);
            return RedirectToAction(nameof(Index));
        }
        return View(publisherToUpdate);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var publisher = await _publisherService.GetPublisherById(id);
        if (publisher == null)
        {
            return NotFound();
        }
        return View(publisher);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _publisherService.DeletePublisher(id);
        return RedirectToAction(nameof(Index));
    }
}