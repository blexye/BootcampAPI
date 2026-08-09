using MediatR;
using BootcampAPI.Application.Interfaces;
using BootcampAPI.Api.Application.Accounts.DTOs;
using BootcampAPI.Api.Application.Accounts.Mappings;
using Microsoft.Extensions.Logging;

namespace BootcampAPI.Api.Application.Accounts.Commands.UpdateAccount
{
	public class UpdateAccountCommandHandler (IAccountRepository repository, ILogger<UpdateAccountCommandHandler> logger) :
		IRequestHandler<UpdateAccountCommand, AccountDTO?>
	{
        private const decimal MinimumRecommendedBalance = 100m;

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

            logger.LogInformation(
                "La cuenta {Id} ({AccountNumber}) fue actualizada exitosamente.",
                account.Id,
                account.AccountNumber);

            if (account.Balance < MinimumRecommendedBalance)
            {
                logger.LogWarning(
                    "La cuenta {AccountNumber} actualizada con balance {Balance} por debajo del recomendado {MinimumBalance}",
                    account.AccountNumber,
                    account.Balance,
                    MinimumRecommendedBalance);
            }

            return account.ToDto();
		}
	}
}
