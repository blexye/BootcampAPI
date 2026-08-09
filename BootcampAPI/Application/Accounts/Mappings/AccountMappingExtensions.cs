using BootcampAPI.Api.Application.Accounts.DTOs;
using BootcampAPI.Domain.Entities;

namespace BootcampAPI.Api.Application.Accounts.Mappings
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
				account.IsActive,
				account.CreatedAt
			);
	}
}
