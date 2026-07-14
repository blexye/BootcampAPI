using BootcampAPI.Application.Interfaces;
using BootcampAPI.Features.Accounts.DTOs;
using MediatR;

namespace BootcampAPI.Features.Accounts.Queries.GetAccountById
{
	public class GetAccountByIdHandler (IAccountRepository repository) : IRequestHandler <GetAccountByIdQuery, AccountDTO?>
	{
		public async Task<AccountDTO?> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
		{
			var account = await repository.GetByIdAsync(request.Id, cancellationToken);

			return account?.ToDto();
		}
	}
}
