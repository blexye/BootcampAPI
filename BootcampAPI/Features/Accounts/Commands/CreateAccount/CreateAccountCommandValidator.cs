using FluentValidation;

namespace BootcampAPI.Features.Accounts.Commands.CreateAccount
{
	public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
	{
		public CreateAccountCommandValidator()
		{
			RuleFor(p => p.AccountNumber)
				.NotEmpty()
				.WithMessage("El número de la cuenta es obligatorio")
				.GreaterThanOrEqualTo(0)
				.WithMessage("Ingrese un número válido");

			RuleFor(p => p.AccountType)
				.NotEmpty()
				.WithMessage("El tipo de cuenta es obligatorio");

			RuleFor(p => p.Currency)
				.NotEmpty()
				.WithMessage("El tipo de moneda es obligatorio");
		}
	}
}
