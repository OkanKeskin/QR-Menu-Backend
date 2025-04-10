using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using QRMenuBackendProject.Domain.Entities;
using System;

namespace QRMenuBackendProject.Persistance.Context
{
	public class QRMenuBackendProjectContext : DbContext
	{
		public QRMenuBackendProjectContext(DbContextOptions options) : base(options) { }

		public DbSet<Accounts> Accounts { get; set; }
		public DbSet<Company> Companys { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Restaurant> Restaurants { get; set; }
		public DbSet<Orders> Orders { get; set; }
		public DbSet<Invoice> Invoice { get; set; }
		public DbSet<FavoriteRestaurant> FavoriteRestaurants { get; set; }
		public DbSet<RestaurantEmployee> RestaurantEmployees { get; set; }
		public DbSet<RestaurantTable> RestaurantTables { get; set; }
		public DbSet<Categories> Categories { get; set; }
		public DbSet<MenuItem> MenuItems { get; set; }
		public DbSet<OrderItems> OrderItems { get; set; }
		public DbSet<RestaurantComment> RestaurantComments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<FavoriteRestaurant>()
			.HasIndex(fr => fr.CustomerId)
			.IsUnique(false);

			modelBuilder.Entity<FavoriteRestaurant>()
				.HasIndex(fr => new { fr.CustomerId, fr.RestaurantId })
				.IsUnique();

			// MenuItem ve Menu arasındaki ilişki için kaskad silmeyi devre dışı bırakma
			modelBuilder.Entity<MenuItem>()
				.HasOne(m => m.Menu)
				.WithMany(m => m.MenuItems)
				.HasForeignKey(m => m.MenuId)
				.OnDelete(DeleteBehavior.NoAction);

			// MenuItem ve Categories arasındaki ilişki için kaskad silmeyi devre dışı bırakma
			modelBuilder.Entity<MenuItem>()
				.HasOne(m => m.Categories)
				.WithMany(c => c.MenuItems)
				.HasForeignKey(m => m.CategoriesId)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Restaurant>()
				.HasOne(r => r.Accounts)
				 .WithMany(c => c.Restaurants)
				 .HasForeignKey(r => r.AccountsId)
				  .OnDelete(DeleteBehavior.NoAction);

			
		}
	}
}
