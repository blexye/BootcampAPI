using FluentValidation;

namespace BootcampAPI.Features.Accounts.Queries.GetAccountById
{
	public class GetAccountByIdValidator : AbstractValidator<GetAccountByIdQuery>
	{
		public GetAccountByIdValidator()
		{
			RuleFor(c => c.Id)
				.NotEmpty()
				.WithMessage("El campo de ID es obligatorio");
		}
	}
}
