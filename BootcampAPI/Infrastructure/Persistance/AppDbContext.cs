using BootcampAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BootcampAPI.Infrastructure.Persistance
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Account> Accounts => Set<Account>();
	}
}
