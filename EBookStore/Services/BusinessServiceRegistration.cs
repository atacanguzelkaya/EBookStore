using EBookStore.Services.Abstracts;
using EBookStore.Services.Concretes;
using EBookStore.Services.ServiceRules;
using System.Reflection;

namespace EBookStore.Services;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
		services.AddAutoMapper(Assembly.GetExecutingAssembly());
		services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<IUserService, UserService>();


		services.AddScoped<CategoryRules>();
		services.AddScoped<PublisherRules>();
		services.AddScoped<AuthorRules>();
		services.AddScoped<BookRules>();
		services.AddScoped<OrderRules>();
		return services;
    }
}