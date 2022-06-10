namespace CodeExample.Services.Interfaces;

public interface IThirdPartyService
{
    Task<bool> HasExistingBookings(string bookingCode);
}