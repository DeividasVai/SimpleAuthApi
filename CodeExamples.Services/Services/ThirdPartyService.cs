using CodeExample.Services.Interfaces;

namespace CodeExample.Services.Services;

public class ThirdPartyService : IThirdPartyService
{
    private readonly bool _isSecond;
    
    public ThirdPartyService(bool isSecond)
    {
        _isSecond = isSecond;
    }

    public Task<bool> HasExistingBookings(string bookingCode)
    {
        return Task.FromResult(_isSecond);
    }
}