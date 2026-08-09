using BootcampAPI.Api.Application.Accounts.DTOs;
using MediatR;

namespace BootcampAPI.Api.Application.Accounts.Commands.UpdateAccount
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
