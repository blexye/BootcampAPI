using BootcampAPI.Endpoints;
using BootcampAPI.Infrastructure.Persistance;
using BootcampAPI.Middleware;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Serilog;
using BootcampAPI.Api.Application;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Async(a => a.Console())
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, loggerConfiguration) =>
    {
        var applicationName = context.Configuration["APPLICATION_NAME"] ?? "BootcampAPI.Api";
        var seqUrl = context.Configuration["Seq:ServerUrl"] ?? "http://localhost:5341";

        loggerConfiguration
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithProperty("Application", applicationName)
            .WriteTo.Async(a => a.Console(
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Application} {Message:lj}{NewLine}{Exception}"))
            .WriteTo.Async(a => a.Seq(seqUrl));
    });
    
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();

    builder.Services.AddControllers();
    builder.Services.AddOpenApi();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    app.UseValidationExceptionHandling();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference(options =>
        {
            options.Title = "BootcampAPI.Api";
        });

        app.UseSwagger();
        app.UseSwaggerUI();
    }

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
}
catch (Exception ex)
{
    Log.Fatal(ex, "BootcampAPI terminó de forma inesperada durante el arranque");
}
finally
{
    Log.CloseAndFlush();
}