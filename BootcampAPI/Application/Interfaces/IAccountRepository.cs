using BootcampAPI.Domain.Entities;

namespace BootcampAPI.Application.Interfaces
{
	public interface IAccountRepository
	{
		Task AddAsync(Account account, CancellationToken cancellationToken = default);
		void Update(Account account);
		Task<Account?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
		Task<IReadOnlyList<Account>> GetAllAsync(CancellationToken cancellationToken = default);
		void Remove(Account account);
		Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
