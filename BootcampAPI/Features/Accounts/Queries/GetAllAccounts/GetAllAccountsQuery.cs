using BootcampAPI.Features.Accounts.DTOs;
using MediatR;

namespace BootcampAPI.Features.Accounts.Queries.GetAllAccounts
{
    public record GetAllAccountsQuery : IRequest<IReadOnlyList<AccountDTO>>;
}
