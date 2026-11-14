using MediatR;
using BootcampAPI.Api.Application.Accounts.DTOs;
using BootcampAPI.Domain.Enums;
using BootcampAPI.Api.Domain.Enums;

namespace BootcampAPI.Api.Application.Accounts.Commands.CreateAccount
{
	public record CreateAccountCommand
	(
		int AccountNumber,
		TiposCuenta AccountType,
		decimal Balance,
		Monedas Currency
	) : IRequest<AccountDTO>;
}
