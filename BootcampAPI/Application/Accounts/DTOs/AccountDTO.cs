using BootcampAPI.Api.Domain.Enums;
using BootcampAPI.Domain.Enums;

namespace BootcampAPI.Api.Application.Accounts.DTOs
{
	public record AccountDTO
	(
		Guid Id,
		int AccountNumber,
		TiposCuenta AccountType,
		decimal Balance,
		Monedas Currency,
		bool IsActive,
		DateTime CreatedAt
	);
}
