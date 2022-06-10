using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CodeExample.Services.Interfaces;
using CodeExamples.Domain.Exceptions.ExceptionTypes;
using CodeExamples.Domain.Models.Authorization;
using CodeExamples.Domain.Models.Bookings;
using CodeExamples.Domain.Models.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CodeExample.Services.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IThirdPartyWrapper _thirdPartyWrapper;
    private readonly AppSettings _appSettings;

    public AuthorizationService(
        IOptions<AppSettings> appSettings,
        IThirdPartyWrapper thirdPartyWrapper)
    {
        _thirdPartyWrapper = thirdPartyWrapper;
        _appSettings = appSettings.Value;
    }

    public async Task<TokenDto> GenerateToken(UserDto user, bool fail = false)
    {
        if (fail)
            throw new NotFoundException("No bookings found");
            
        var bookingReference = await HasThirdPartyBookings(user);
        if (!bookingReference.HasBooking)
            throw new NotFoundException("No bookings found");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Jwt.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return TokenDto.Create(tokenHandler.WriteToken(token),
            bookingReference.RedirectUrl, bookingReference.Account);
    }

    private async Task<BookingReference> HasThirdPartyBookings(UserDto user)
    {
        var bookingData = await _thirdPartyWrapper.UseFirst().HasExistingBookings(user.BookingRef);
        if (bookingData)
            return BookingReference.FirstBooking();

        bookingData = await _thirdPartyWrapper.UseSecond().HasExistingBookings(user.BookingRef);
        return !bookingData ? BookingReference.NotFound() : BookingReference.SecondBooking();
    }
}