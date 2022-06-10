using CodeExamples.Domain.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CodeExample.Controllers;

[ApiController]
public class BaseController : Controller
{
    #region Generic responses
    
    [NonAction]
    protected static GenericResponse<TModel> Ok<TModel>(TModel content, string message = null!)
    {
        return new GenericResponse<TModel>
        {
            Content = content,
            Message = string.IsNullOrWhiteSpace(message) && content == null
                ? "The request was successful, but no content has been retrieved. Try changing filter properties."
                : message,
            StatusCode = 200
        };
    }

    [NonAction]
    protected static GenericResponse<TModel?> OkNoContent<TModel>(string message = null!)
    {
        return new GenericResponse<TModel?>
        {
            Content = default,
            Message = message,
            StatusCode = 200
        };
    }

    [NonAction]
    protected static GenericResponse<TModel?> Unauthorized<TModel>(string message)
    {
        return new GenericResponse<TModel?>
        {
            StatusCode = StatusCodes.Status401Unauthorized,
            Content = default,
            Message = message
        };
    }

    [NonAction]
    protected static GenericResponse<TModel?> NotFoundResponse<TModel>(string message)
    {
        return new GenericResponse<TModel?>
        {
            StatusCode = StatusCodes.Status404NotFound,
            Content = default,
            Message = message
        };
    }

    [NonAction]
    protected static GenericResponse<TModel?> InternalError<TModel>(string message)
    {
        return new GenericResponse<TModel?>
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            Content = default,
            Message = message
        };
    }
    
    #endregion
}