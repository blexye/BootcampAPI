using BootcampAPI.Application.Common.Behaviors;
using BootcampAPI.Endpoints;
using BootcampAPI.Features.Accounts.Commands.CreateAccount;
using BootcampAPI.Infrastructure;
using BootcampAPI.Middleware;
using FluentValidation;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblyContaining<CreateAccountCommandValidator>();

builder.Services.AddTransient
(
	typeof(IPipelineBehavior<,>),
	typeof(ValidationBehavior<,>)
);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMediatR(cfg =>
{
	cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseValidationExceptionHandling();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();

	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapAccountEndpoints();

app.Run();
