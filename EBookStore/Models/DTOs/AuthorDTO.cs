﻿namespace EBookStore.Models.DTOs;

public class AuthorDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

	public string FullName => $"{FirstName} {LastName}";
}