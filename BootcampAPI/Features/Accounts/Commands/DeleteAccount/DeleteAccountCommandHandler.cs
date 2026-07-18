using BootcampAPI.Application.Interfaces;
using MediatR;

namespace BootcampAPI.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler(IAccountRepository repository) : IRequestHandler<DeleteAccountCommand, bool>
    {
        public async Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await repository.GetByIdAsync(request.Id, cancellationToken);

            if (account is null)
                return false;

            account.IsActive = false;
            account.DeletedAt = DateTime.UtcNow;

            //repository.Remove(account);

            await repository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
