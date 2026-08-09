using BootcampAPI.Api.Application.Accounts.DTOs;
using MediatR;

namespace BootcampAPI.Api.Application.Accounts.Queries.GetAccountById
{
	public record GetAccountByIdQuery
	(
		Guid Id
	) : IRequest<AccountDTO?>;
}
