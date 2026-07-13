using BootcampAPI.Features.Accounts.DTOs;
using MediatR;

namespace BootcampAPI.Features.Accounts.Commands.UpdateAccount
{
	public record UpdateAccountCommand
	(
		Guid Id,
		int AccountNumber,
		string AccountType,
		decimal Balance,
		string Currency
	) : IRequest<AccountDTO?>;
}
