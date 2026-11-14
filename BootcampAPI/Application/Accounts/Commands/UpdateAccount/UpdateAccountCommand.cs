using BootcampAPI.Api.Application.Accounts.DTOs;
using BootcampAPI.Api.Domain.Enums;
using BootcampAPI.Domain.Enums;
using MediatR;

namespace BootcampAPI.Api.Application.Accounts.Commands.UpdateAccount
{
	public record UpdateAccountCommand
	(
		Guid Id,
		int AccountNumber,
		TiposCuenta AccountType,
		decimal Balance,
		Monedas Currency
	) : IRequest<AccountDTO?>;
}
