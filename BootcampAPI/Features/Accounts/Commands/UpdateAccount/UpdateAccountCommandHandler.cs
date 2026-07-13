using MediatR;
using BootcampAPI.Application.Interfaces;
using BootcampAPI.Features.Accounts.DTOs;

namespace BootcampAPI.Features.Accounts.Commands.UpdateAccount
{
	public class UpdateAccountCommandHandler (IAccountRepository repository) : IRequestHandler<UpdateAccountCommand, AccountDTO?>
	{
		public async Task<AccountDTO?> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
		{
			var account = await repository.GetByIdAsync(request.Id, cancellationToken);

			if (account is null)
				return null;
			
			account.AccountNumber = request.AccountNumber;
			account.AccountType = request.AccountType;
			account.Currency = request.Currency;
			account.Balance = request.Balance;

			repository.Update(account);
			await repository.SaveChangesAsync(cancellationToken);

			return account.ToDto();
		}
	}
}
