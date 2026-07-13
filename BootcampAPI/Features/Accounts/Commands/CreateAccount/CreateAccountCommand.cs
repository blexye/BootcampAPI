using MediatR;
using BootcampAPI.Features.Accounts.DTOs;

namespace BootcampAPI.Features.Accounts.Commands.CreateAccount
{
	public record CreateAccountCommand
	(
		int AccountNumber,
		string AccountType,
		decimal Balance,
		string Currency
	) : IRequest<AccountDTO>;
}
