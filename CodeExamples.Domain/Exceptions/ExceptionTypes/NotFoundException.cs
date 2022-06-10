using System.Net;

namespace CodeExamples.Domain.Exceptions.ExceptionTypes;

public class NotFoundException : Exception, ICustomException
{
    public NotFoundException(string? message = null) : base(message)
    {
    }

    public int StatusCode => (int)HttpStatusCode.NotFound;
}