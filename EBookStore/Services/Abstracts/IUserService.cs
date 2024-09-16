namespace EBookStore.Services.Abstracts;
public interface IUserService
{
	Task<string> GetUserIdAsync();
}