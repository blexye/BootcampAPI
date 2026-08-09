namespace BootcampAPI.Api.Application.Accounts.DTOs
{
	public record AccountDTO
	(
		Guid Id,
		int AccountNumber,
		string AccountType,
		decimal Balance,
		string Currency,
		bool IsActive,
		DateTime CreatedAt
	);
}
