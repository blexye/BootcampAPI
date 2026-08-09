using BootcampAPI.Api.Application.Accounts.DTOs;
using BootcampAPI.Api.Application.Accounts.Mappings;
using BootcampAPI.Application.Interfaces;
using MediatR;

namespace BootcampAPI.Api.Application.Accounts.Queries.GetAllAccounts
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
