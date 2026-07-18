namespace BootcampAPI.Features.Accounts.DTOs
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
