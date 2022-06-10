using System;
using System.Threading.Tasks;
using CodeExample.Extensions;
using CodeExample.Services.Interfaces;
using CodeExamples.Domain.Exceptions.ExceptionTypes;
using CodeExamples.Domain.Models.Authorization;
using CodeExamples.Domain.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CodeExample.Controllers;

[Route("api/[controller]")]
public class AuthorizationController : BaseController
{
    private readonly IAuthorizationService _authorizationService;

    public AuthorizationController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    /// <summary>
    /// Will always authorize
    /// </summary>
    /// <param name="userDto"></param>
    /// <param name="fail">Purely for testing</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPost("[action]")]
    public async Task<GenericResponse<TokenDto>> Authorize(UserDto userDto, [FromQuery] bool fail = false)
    {
        if (!ModelState.IsValid)
            throw new BadRequestException(ModelState.ErrorMessages());
        
        return Ok(await _authorizationService.GenerateToken(userDto, fail));
    }
}