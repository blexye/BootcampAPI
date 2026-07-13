using BootcampAPI.Domain.Entities;

namespace BootcampAPI.Features.Accounts.DTOs
{
	public static class AccountMappingExtensions
	{
		public static AccountDTO ToDto(this Account account) =>
			new
			(
				account.Id,
				account.AccountNumber,
				account.AccountType,
				account.Balance,
				account.Currency,
				account.IsActive
			);
	}
}
