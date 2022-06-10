namespace CodeExamples.Domain.Models.Helpers;

public class AppSettings
{
    public string Version { get; set; } = string.Empty;
    public Jwt Jwt { get; set; } = new();
}