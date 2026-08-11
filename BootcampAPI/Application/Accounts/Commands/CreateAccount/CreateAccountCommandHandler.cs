using BootcampAPI.Api.Application.Accounts.DTOs;
using BootcampAPI.Api.Application.Accounts.Mappings;
using BootcampAPI.Application.Interfaces;
using BootcampAPI.Domain.Entities;
using MediatR;

namespace BootcampAPI.Api.Application.Accounts.Commands.CreateAccount
{
	public class CreateAccountCommandHandler (IAccountRepository repository, ILogger<CreateAccountCommandHandler> logger) :
        IRequestHandler<CreateAccountCommand, AccountDTO>
	{
        private const decimal MinimumRecommendedBalance = 100m;

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

            logger.LogInformation
            (
                "La cuenta {Id} ({AccountNumber}) fue creada exitosamente.",
                account.Id,
                account.AccountNumber
            );

            if (account.Balance < MinimumRecommendedBalance)
            {
                logger.LogWarning
                (
                    "La cuenta {AccountNumber} creado con balance {Balance} por debajo del recomendado {MinimumBalance}",
                    account.AccountNumber,
                    account.Balance,
                    MinimumRecommendedBalance
                );
            }

            return account.ToDto();
		}
	}
}
