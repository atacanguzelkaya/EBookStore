using EBookStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EBookStore.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Category>()
			.HasMany(c => c.Books)
			.WithOne(b => b.Category)
			.HasForeignKey(b => b.CategoryId);

		modelBuilder.Entity<Author>()
			.HasMany(a => a.Books)
			.WithOne(b => b.Author)
			.HasForeignKey(b => b.AuthorId);

		modelBuilder.Entity<Publisher>()
			.HasMany(p => p.Books)
			.WithOne(b => b.Publisher)
			.HasForeignKey(b => b.PublisherId);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId);

        modelBuilder.Entity<Cart>()
            .HasMany(c => c.CartItems)
            .WithOne(ci => ci.Cart)
            .HasForeignKey(ci => ci.CartId);

  //      modelBuilder.Entity<OrderItem>()
  //          .HasOne(oi => oi.Book)
  //          .WithMany()
  //          .HasForeignKey(oi => oi.BookId);
		//modelBuilder.Entity<CartItem>()
	 //       .HasOne(ci => ci.Book)
	 //       .WithMany()
	 //       .HasForeignKey(ci => ci.BookId);


        //// Soft delete global query filter
        modelBuilder.Entity<Book>().HasQueryFilter(e => !e.DeletedDate.HasValue);
        modelBuilder.Entity<Category>().HasQueryFilter(e => !e.DeletedDate.HasValue);
        modelBuilder.Entity<Author>().HasQueryFilter(e => !e.DeletedDate.HasValue);
        modelBuilder.Entity<Publisher>().HasQueryFilter(e => !e.DeletedDate.HasValue);
        modelBuilder.Entity<Order>().HasQueryFilter(e => !e.DeletedDate.HasValue);
        modelBuilder.Entity<OrderItem>().HasQueryFilter(e => !e.DeletedDate.HasValue);
        modelBuilder.Entity<Cart>().HasQueryFilter(e => !e.DeletedDate.HasValue);
		modelBuilder.Entity<CartItem>().HasQueryFilter(e => !e.DeletedDate.HasValue);
	}
}
