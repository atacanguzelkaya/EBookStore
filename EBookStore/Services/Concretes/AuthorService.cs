using EBookStore.Models;
using EBookStore.Repositories.Abstracts;
using EBookStore.Models.DTOs;
using EBookStore.Services.Abstracts;
using AutoMapper;
using EBookStore.Services.ServiceRules;

namespace EBookStore.Services.Concretes;

public class AuthorService : IAuthorService
{
	private readonly IAuthorRepository _authorRepository;
	private readonly IMapper _mapper;
	private readonly AuthorRules _authorRules;

	public AuthorService(IAuthorRepository authorRepository, IMapper mapper, AuthorRules authorRules)
	{
		_authorRepository = authorRepository;
		_mapper = mapper;
		_authorRules = authorRules;
	}

	public async Task<IEnumerable<Author>> GetAllAuthors()
	{
		return await _authorRepository.GetAllAsync();
	}

	public async Task<Author> GetAuthorById(int id)
	{
		var author = await _authorRepository.GetByIdAsync(id);
		await _authorRules.AuthorNotFoundException(author);
		return author;
	}

	public async Task AddAuthor(AuthorDTO author)
	{
		var authorToAdd = _mapper.Map<Author>(author);
		await _authorRepository.AddAsync(authorToAdd);
	}

	public async Task UpdateAuthor(AuthorDTO author)
	{
		var authorUpdated = await _authorRepository.GetByIdAsync(author.Id);
		await _authorRules.AuthorNotFoundException(authorUpdated);
		_mapper.Map(author, authorUpdated);
		await _authorRepository.UpdateAsync(authorUpdated);
	}

	public async Task DeleteAuthor(int id)
	{
		var author = await _authorRepository.GetByIdAsync(id);
		await _authorRules.AuthorNotFoundException(author);
		await _authorRepository.DeleteAsync(author);
	}
}