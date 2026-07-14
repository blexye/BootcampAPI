using BootcampAPI.Application.Interfaces;
using BootcampAPI.Domain.Entities;
using BootcampAPI.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BootcampAPI.Infrastructure.Repositories
{
	public class AccountRepository (AppDbContext context) : IAccountRepository
	{
		public async Task AddAsync(Account account, CancellationToken cancellationToken = default) =>
			await context.Accounts.AddAsync(account, cancellationToken);

		public void Update(Account account) => context.Accounts.Update(account);

		public async Task<Account?> GetByIdAsync(Guid id, CancellationToken cancellation = default) =>
			await context.Accounts.FirstOrDefaultAsync(c => c.Id == id, cancellation);

		public async Task<IReadOnlyList<Account>> GetAllAsync(CancellationToken cancellationToken = default) =>
			await context.Accounts.AsNoTracking().ToListAsync(cancellationToken);

		public void Remove(Account account) => context.Accounts.Remove(account);

		public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return await context.SaveChangesAsync(cancellationToken) > 0;
		}
	}
}
