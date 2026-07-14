using MediatR;

namespace BootcampAPI.Features.Accounts.Commands.DeleteAccount
{
    public record DeleteAccountCommand(Guid Id) : IRequest<bool>;
}
