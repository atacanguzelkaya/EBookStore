using AutoMapper;
using EBookStore.Models.DTOs;
using EBookStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EBookStore.Mapping;

public class BookProfile : Profile
{
	public BookProfile()
	{
		CreateMap<BookDTO, Book>().ReverseMap();

		CreateMap<AuthorDTO, Author>().ReverseMap();

		CreateMap<CategoryDTO, Category>().ReverseMap();

		CreateMap<PublisherDTO, Publisher>().ReverseMap();
	}
}
