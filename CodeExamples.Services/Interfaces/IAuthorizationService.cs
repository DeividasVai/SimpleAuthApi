using CodeExamples.Domain.Models.Authorization;

namespace CodeExample.Services.Interfaces;

public interface IAuthorizationService
{
    Task<TokenDto> GenerateToken(UserDto user, bool fail = false);
}