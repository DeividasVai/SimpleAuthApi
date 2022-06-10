using CodeExample.Services.Interfaces;
using CodeExamples.Domain.Models.Helpers;
using Microsoft.Extensions.Options;

namespace CodeExample.Services.Services;

public class ThirdPartyWrapper : IThirdPartyWrapper
{
    private readonly AppSettings _appSettings;

    // initialize the models easily with different settings and chain the call for easier access.
    public ThirdPartyWrapper(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public IThirdPartyService UseFirst()
    {
        return new ThirdPartyService(false);
    }

    public IThirdPartyService UseSecond()
    {
        return new ThirdPartyService(true);
    }
}