using EBookStore.Services.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace EBookStore.Services.Concretes;

public class UserService : IUserService
{
	private readonly UserManager<IdentityUser> _userManager;
	private readonly IHttpContextAccessor _httpContextAccessor;

	public UserService(UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
	{
		_userManager = userManager;
		_httpContextAccessor = httpContextAccessor;
	}

	public async Task<string> GetUserIdAsync()
	{
		var principal = _httpContextAccessor.HttpContext.User;
		return _userManager.GetUserId(principal);
	}
}
