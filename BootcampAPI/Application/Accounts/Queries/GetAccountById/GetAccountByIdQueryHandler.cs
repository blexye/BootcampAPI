using BootcampAPI.Api.Application.Accounts.DTOs;
using BootcampAPI.Api.Application.Accounts.Mappings;
using BootcampAPI.Application.Interfaces;
using MediatR;

namespace BootcampAPI.Api.Application.Accounts.Queries.GetAccountById
{
	public class GetAccountByIdQueryHandler (IAccountRepository repository) : IRequestHandler <GetAccountByIdQuery, AccountDTO?>
	{
		public async Task<AccountDTO?> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
		{
			var account = await repository.GetByIdAsync(request.Id, cancellationToken);

			return account?.ToDto();
		}
	}
}
