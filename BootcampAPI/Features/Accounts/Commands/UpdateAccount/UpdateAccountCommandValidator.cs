using FluentValidation;

namespace BootcampAPI.Features.Accounts.Commands.UpdateAccount
{
	public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
	{
		public UpdateAccountCommandValidator()
		{
			RuleFor(p => p.AccountNumber)
				.NotEmpty()
				.WithMessage("El número de la cuenta es obligatorio");

			RuleFor(p => p.AccountType)
				.NotEmpty()
				.WithMessage("El tipo de cuenta es obligatorio");

			RuleFor(p => p.Currency)
				.NotEmpty()
				.WithMessage("El tipo de moneda es obligatorio");
		}
	}
}
