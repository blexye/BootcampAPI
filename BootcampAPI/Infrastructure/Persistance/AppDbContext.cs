using BootcampAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BootcampAPI.Infrastructure.Persistance
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public DbSet<Account> Accounts => Set<Account>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Account>(entity =>
			{
				entity.HasKey(c => c.Id);
				entity.Property(c => c.AccountNumber).IsRequired().HasMaxLength(20);
				entity.Property(c => c.AccountType).IsRequired().HasMaxLength(30);
				entity.Property(c => c.Balance).IsRequired();
				entity.Property(c => c.Currency).IsRequired().HasMaxLength(3);
			});
		}
	}
}
