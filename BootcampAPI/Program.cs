using BootcampAPI.Application.Common.Behaviors;
using BootcampAPI.Endpoints;
using BootcampAPI.Features.Accounts.Commands.CreateAccount;
using BootcampAPI.Infrastructure;
using BootcampAPI.Infrastructure.Persistance;
using BootcampAPI.Middleware;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Scalar.AspNetCore;

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

app.MapOpenApi();
app.MapScalarApiReference();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapAccountEndpoints();

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
	db.Database.Migrate();
}

app.Run();
