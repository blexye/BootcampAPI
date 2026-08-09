using FluentValidation;
using System.Diagnostics;

namespace BootcampAPI.Middleware
{
    public static class ValidationExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidationExceptionHandling(this IApplicationBuilder app) =>
            app.Use(async (context, next) =>
            {
                var logger = context.RequestServices.GetRequiredService<ILoggerFactory>()
                    .CreateLogger("BootcampAPI.Api.Middleware.ExceptionHandling");

                var stopwatch = Stopwatch.StartNew();

                try
                {
                    await next(context);
                    stopwatch.Stop();

                    logger.LogInformation(
                        "HTTP {Method} {Path} respondió {StatusCode} en {ElapsedMilliseconds} ms",
                        context.Request.Method,
                        context.Request.Path,
                        context.Response.StatusCode,
                        stopwatch.ElapsedMilliseconds);
                }
                catch (ValidationException ex)
                {
                    stopwatch.Stop();

                    var errors = ex.Errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

                    logger.LogWarning(
                        "Validación fallida para {Method} {Path}: {ErrorCount} error(es) -> {@Errors}",
                        context.Request.Method,
                        context.Request.Path,
                        errors.Count,
                        errors);

                    context.Response.StatusCode = StatusCodes.Status400BadRequest;

                    await context.Response.WriteAsJsonAsync(new
                    {
                        title = "Error en la validación",
                        status = StatusCodes.Status400BadRequest,
                        errors
                    });
                }
                catch (Exception ex)
                {
                    stopwatch.Stop();

                    logger.LogError(
                        ex,
                        "Excepción no controlada procesando {Method} {Path}",
                        context.Request.Method,
                        context.Request.Path);

                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    await context.Response.WriteAsJsonAsync(new
                    {
                        title = "Ocurrió un error inesperado",
                        status = StatusCodes.Status500InternalServerError
                    });
                }
            });
    }
}
