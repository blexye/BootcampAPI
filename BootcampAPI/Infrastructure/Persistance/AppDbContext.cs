using BootcampAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BootcampAPI.Infrastructure.Persistance
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public DbSet<Account> Accounts => Set<Account>();
		public DbSet<DepositoCheque> DepositoCheques => Set<DepositoCheque>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Account>(entity =>
			{
				entity.HasKey(c => c.Id);
				entity.Property(c => c.AccountNumber).IsRequired().HasMaxLength(20);
				entity.Property(c => c.AccountType).IsRequired().HasConversion<string>();
				entity.Property(c => c.Balance).IsRequired().HasConversion<string>();
				entity.Property(c => c.Currency).IsRequired().HasMaxLength(3);
			});

			modelBuilder.Entity<DepositoCheque>(entity =>
			{
				entity.HasKey(c => c.IdDepositoCheque);
				entity.Property(c => c.NumeroCheque).IsRequired().HasMaxLength(30);
				entity.Property(c => c.BancoEmisor).IsRequired().HasMaxLength(100);
				entity.Property(c => c.MontoNumero).IsRequired().HasPrecision(18, 2);
				entity.Property(c => c.MontoLetra).IsRequired().HasMaxLength(250);
				entity.Property(c => c.Currency).IsRequired().HasMaxLength(3);

				entity.Property(c => c.EstadoDeposito)
					.IsRequired()
					.HasConversion<string>()
					.HasMaxLength(40);

				entity.Property(c => c.FechaSolicitudDepositoCheque).IsRequired();
				entity.Property(c => c.FechaUltimaModificacionDepositoCheque).IsRequired(false);
				entity.Property(c => c.FechaRevisionDepositoCheque).IsRequired(false);
				entity.Property(c => c.MotivoRechazo).IsRequired(false).HasMaxLength(500);
				entity.Property(c => c.FotoFrontalRuta).IsRequired().HasMaxLength(500);
				entity.Property(c => c.FotoDorsalRuta).IsRequired().HasMaxLength(500);

				entity.HasOne<Account>()
					.WithMany()
					.HasForeignKey(c => c.IdAccount)
					.OnDelete(DeleteBehavior.Restrict);

				entity.HasIndex(c => c.IdAccount);
				entity.HasIndex(c => c.EstadoDeposito);
			});
		}
	}
}
