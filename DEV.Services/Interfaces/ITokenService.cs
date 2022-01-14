using DEV.Entities;

namespace DEV.Services.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, User user);
    }
}
