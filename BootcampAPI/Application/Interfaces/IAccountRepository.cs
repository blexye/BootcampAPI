using BootcampAPI.Domain.Entities;

namespace BootcampAPI.Application.Interfaces
{
	public interface IAccountRepository
	{
		Task AddAsync(Account account, CancellationToken cancellationToken = default);
		void Update(Account account);
		Task<Account?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
		Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
