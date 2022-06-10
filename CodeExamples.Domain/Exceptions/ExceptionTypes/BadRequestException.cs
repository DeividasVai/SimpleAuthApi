using System.Net;

namespace CodeExamples.Domain.Exceptions.ExceptionTypes;

public class BadRequestException : Exception, ICustomException
{
    public BadRequestException(string? message = null) : base(message)
    {
    }

    public int StatusCode { get; } = (int) HttpStatusCode.BadRequest;
}