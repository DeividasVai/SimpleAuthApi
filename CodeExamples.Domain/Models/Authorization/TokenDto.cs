namespace CodeExamples.Domain.Models.Authorization;

public class TokenDto
{
    public string? Token { get; init; }

    public string RedirectUrl { get; init; } = string.Empty;

    public string Account { get; init; } = string.Empty;

    public static TokenDto Create(string? token, string redirectUrl, string account)
    {
        return new TokenDto
        {
            Token = token,
            RedirectUrl = redirectUrl,
            Account = account
        };
    }
}