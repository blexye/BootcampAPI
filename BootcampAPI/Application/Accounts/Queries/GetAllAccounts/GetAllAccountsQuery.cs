using BootcampAPI.Api.Application.Accounts.DTOs;
using MediatR;

namespace BootcampAPI.Api.Application.Accounts.Queries.GetAllAccounts
{
    public record GetAllAccountsQuery : IRequest<IReadOnlyList<AccountDTO>>;
}
