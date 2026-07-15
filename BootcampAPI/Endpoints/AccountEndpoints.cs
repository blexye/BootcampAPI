using MediatR;
using BootcampAPI.Features.Accounts.Commands.CreateAccount;
using BootcampAPI.Features.Accounts.DTOs;
using BootcampAPI.Features.Accounts.Commands.UpdateAccount;
using BootcampAPI.Features.Accounts.Queries.GetAccountById;
using BootcampAPI.Features.Accounts.Queries.GetAllAccounts;
using BootcampAPI.Features.Accounts.Commands.DeleteAccount;

namespace BootcampAPI.Endpoints
{
	public static class AccountEndpoints
	{
		public static void MapAccountEndpoints(this WebApplication app)
		{
			var group = app.MapGroup("/api/minimal").WithTags("Accounts");

            group.MapGet("", async (ISender sender, CancellationToken cancellationToken) =>
                Results.Ok(await sender.Send(new GetAllAccountsQuery(), cancellationToken)))
                .Produces<IReadOnlyList<AccountDTO>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithDescription("Obtener todas las cuentas")
				.WithSummary("Obtener todos los datos de todas las cuentas");

            group.MapGet("{id:guid}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
            {
                var account = await sender.Send(new GetAccountByIdQuery(id), cancellationToken);

                return account is null ? Results.NotFound() : Results.Ok(account);
            })
                .Produces<AccountDTO>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithDescription("Obtener una cuenta por ID")
				.WithSummary("Obtener los datos de una cuenta por ID");

            group.MapPost("/accounts", async (CreateAccountCommand command, ISender sender, CancellationToken cancellationToken) =>
			{
				var account = await sender.Send(command, cancellationToken);
				return Results.Created($"api/minimal/{account.Id}", account);
			})
				.Produces<AccountDTO>(StatusCodes.Status201Created)
				.Produces(StatusCodes.Status400BadRequest)
				.Produces(StatusCodes.Status500InternalServerError)
				.WithDescription("Crear cuenta nueva")
				.WithSummary("Endpoint para crear una nueva cuenta");

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
				.Produces(StatusCodes.Status500InternalServerError)
				.WithDescription("Modificar una cuenta")
				.WithSummary("Actualizar los datos de una cuenta existente");
			
			group.MapDelete("{id:guid}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
			{
				var deleted = await sender.Send(new DeleteAccountCommand(id), cancellationToken);

				return deleted ? Results.NoContent() : Results.NotFound();
			})
				.Produces(StatusCodes.Status204NoContent)
				.Produces(StatusCodes.Status400BadRequest)
				.Produces(StatusCodes.Status500InternalServerError)
				.WithDescription("Eliminar una cuenta por ID")
				.WithSummary("Eliminar una cuenta");
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