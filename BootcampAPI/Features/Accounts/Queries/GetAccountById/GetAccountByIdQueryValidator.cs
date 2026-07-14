using FluentValidation;

namespace BootcampAPI.Features.Accounts.Queries.GetAccountById
{
	public class GetAccountByIdQueryValidator : AbstractValidator<GetAccountByIdQuery>
	{
		public GetAccountByIdQueryValidator()
		{
			RuleFor(c => c.Id)
				.NotEmpty()
				.WithMessage("El campo de ID es obligatorio");
		}
	}
}
