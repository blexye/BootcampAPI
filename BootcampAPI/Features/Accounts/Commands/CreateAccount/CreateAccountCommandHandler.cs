using MediatR;
using BootcampAPI.Domain.Entities;
using BootcampAPI.Features.Accounts.DTOs;
using BootcampAPI.Application.Interfaces;

namespace BootcampAPI.Features.Accounts.Commands.CreateAccount
{
	public class CreateAccountCommandHandler (IAccountRepository repository) : IRequestHandler<CreateAccountCommand, AccountDTO>
	{
		public async Task<AccountDTO> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
		{
			var account = new Account
			{
				Id = Guid.NewGuid(),
				AccountNumber = request.AccountNumber,
				AccountType = request.AccountType,
				Balance = request.Balance,
				Currency = request.Currency,
				CreatedAt = DateTime.UtcNow
			};

			await repository.AddAsync(account, cancellationToken);
			await repository.SaveChangesAsync(cancellationToken);

			return account.ToDto();
		}
	}
}
