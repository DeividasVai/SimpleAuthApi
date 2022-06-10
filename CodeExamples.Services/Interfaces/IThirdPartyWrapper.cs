namespace CodeExample.Services.Interfaces;

public interface IThirdPartyWrapper
{
    IThirdPartyService UseFirst();
    IThirdPartyService UseSecond();
}