using BootcampAPI.Application.Interfaces;
using BootcampAPI.Features.Accounts.DTOs;
using MediatR;

namespace BootcampAPI.Features.Accounts.Queries.GetAllAccounts
{
    public class GetAllAccountsQueryHandler(IAccountRepository repository) : IRequestHandler<GetAllAccountsQuery, IReadOnlyList<AccountDTO>>
    {
        public async Task<IReadOnlyList<AccountDTO>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var accounts = await repository.GetAllAsync(cancellationToken);

            return accounts.Select(c => c.ToDto()).ToList();
        }

    }
}
