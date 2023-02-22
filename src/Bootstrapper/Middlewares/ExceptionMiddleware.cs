using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace Bootstrapper.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (SchoolOrganizerException exception)
        {
            context.Response.StatusCode = exception.StatusCode;
            context.Response.Headers.Add("content-type", "application/json");

            var json = JsonSerializer.Serialize(new {ErrorCode = exception.StatusCode, exception.Message});
            await context.Response.WriteAsync(json);
            
            _logger.LogError(exception, $"{exception.GetType().Name} Message: {exception.Message}");
        }
        catch(Exception exception)
        {
            context.Response.StatusCode = 500;
            context.Response.Headers.Add("content-type", "application/json");

            var json = JsonSerializer.Serialize(new {ErrorCode = "500", exception.Message});
            await context.Response.WriteAsync(json);
            
            _logger.LogError(exception, $"{exception.GetType().Name} Message: {exception.Message}");
        }
        
        
    }
}