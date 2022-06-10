using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CodeExample.Extensions;

public static class ModelStateExtension
{
    public static string ErrorMessages(this ModelStateDictionary modelState)
    {
        return string.Join(" | ", modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
    }
}