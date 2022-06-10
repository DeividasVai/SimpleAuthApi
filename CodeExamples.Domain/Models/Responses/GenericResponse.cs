namespace CodeExamples.Domain.Models.Responses;

public class GenericResponse<TModel>
{
    public TModel? Content { get; set; }

    public int StatusCode { get; set; }

    public string? Message { get; set; }

    public static GenericResponse<TModel?> GenerateResponse(int statusCode, TModel content = default!,
        string message = null!)
    {
        return new GenericResponse<TModel?>
        {
            StatusCode = statusCode,
            Content = content,
            Message = message
        };
    }
}