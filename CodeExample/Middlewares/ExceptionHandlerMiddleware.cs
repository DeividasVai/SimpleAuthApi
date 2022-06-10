using System.Text.Json;
using CodeExamples.Domain.Exceptions;
using CodeExamples.Domain.Models.Responses;

namespace CodeExample.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var customExceptionStatusCode = context.Response.StatusCode == StatusCodes.Status200OK
            ? StatusCodes.Status500InternalServerError
            : context.Response.StatusCode;

        if (exception is ICustomException customException)
        {
            context.Response.StatusCode = StatusCodes.Status200OK;
            customExceptionStatusCode = customException.StatusCode;
        }

        var resp = GenericResponse<string>.GenerateResponse(customExceptionStatusCode, message: exception.Message);
        await context.Response.WriteAsync(JsonSerializer.Serialize(resp,
            new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase}));
    }
}