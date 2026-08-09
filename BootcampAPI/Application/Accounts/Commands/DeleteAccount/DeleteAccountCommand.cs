using MediatR;

namespace BootcampAPI.Api.Application.Accounts.Commands.DeleteAccount
{
    public record DeleteAccountCommand(Guid Id) : IRequest<bool>;
}
