using MediatR;
using BootcampAPI.Features.Accounts.Commands.CreateAccount;
using BootcampAPI.Features.Accounts.DTOs;
using BootcampAPI.Features.Accounts.Commands.UpdateAccount;

namespace BootcampAPI.Endpoints
{
	public static class AccountEndpoints
	{
		public static void MapAccountEndpoints(this WebApplication app)
		{
			var group = app.MapGroup("/api/minimal").WithTags("Accounts");

			// Crear cuenta
			group.MapPost("/accounts", async (CreateAccountCommand command, ISender sender, CancellationToken cancellationToken) =>
			{
				var account = await sender.Send(command, cancellationToken);
				return Results.Created($"api/minimal/{account.Id}", account);
			})
				.Produces<AccountDTO>(StatusCodes.Status201Created)
				.Produces(StatusCodes.Status400BadRequest)
				.Produces(StatusCodes.Status500InternalServerError);

			// Modificar cuenta
			group.MapPut("/accounts/{id:guid}", async (Guid id, UpdateAccountBody body, ISender sender, CancellationToken cancellationToken) =>
			{
				var account = await sender.Send(new UpdateAccountCommand
				(
					id,
					body.AccountNumber,
					body.AccountType,
					body.Balance,
					body.Currency
				), cancellationToken);

				return account is null ? Results.NotFound() : Results.Ok();
			})
				.Produces<AccountDTO>(StatusCodes.Status200OK)
				.Produces(StatusCodes.Status400BadRequest)
				.Produces(StatusCodes.Status500InternalServerError);
		}
	}
}

public record UpdateAccountBody
(
	int AccountNumber,
	string AccountType,
	decimal Balance,
	string Currency
);