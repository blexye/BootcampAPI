using BootcampAPI.Features.Accounts.DTOs;
using MediatR;

namespace BootcampAPI.Features.Accounts.Queries.GetAccountById
{
	public record GetAccountByIdQuery
	(
		Guid Id
	) : IRequest<AccountDTO?>;
}
