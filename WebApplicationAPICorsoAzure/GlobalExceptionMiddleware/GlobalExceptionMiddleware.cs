

using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace WebApplicationAPICorsoAzure.GlobalExceptionMiddleware;

public class GlobalExceptionMiddleware //classe middleware per la gestione globale delle eccezioni
{
    public readonly RequestDelegate next;
    public readonly ILogger<GlobalExceptionMiddleware> logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }
    private static Task HandleException(HttpContext context, Exception ex) //tracciamento dell'errore
    {
        var (statusCode, title) = ex switch
        {
            KeyNotFoundException => (StatusCodes.Status404NotFound, $"Risorsa non trovata: {ex}"),
            InvalidProgramException => (StatusCodes.Status406NotAcceptable, $"Invalid Operation: {ex}"),
            //_ => (StatusCodes.Status200OK, $"{ex}"),
            ValidationException => (StatusCodes.Status400BadRequest, $"Bad Request: {ex}"),
            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, $"Non autorizzato: {ex}"),
            _ => (StatusCodes.Status500InternalServerError, $"Errore interno del server: {ex}")
        };
        var traceId = Activity.Current?.Id ?? context.TraceIdentifier;

        var problemaDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = ex.Message,
            Instance = context.Request.Path
        };
        problemaDetails.Extensions["TraceId"] = traceId;

        return context.Response.WriteAsJsonAsync(problemaDetails);
    }

    public async Task InvokeAsync(HttpContext context) //creazione response per gli erre
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Si è verificato un errore nell'applicazione");
            await HandleException(context, ex);
        }
    }
}
