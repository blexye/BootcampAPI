using MediatR;
using BootcampAPI.Api.Application.Accounts.DTOs;

namespace BootcampAPI.Api.Application.Accounts.Commands.CreateAccount
{
	public record CreateAccountCommand
	(
		int AccountNumber,
		string AccountType,
		decimal Balance,
		string Currency
	) : IRequest<AccountDTO>;
}
