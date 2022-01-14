using DEV.Data.Implementations;
using DEV.Data.Interfaces;
using DEV.Entities;
using DEV.Services.Interfaces;
using DEV.Utils;
using Microsoft.Extensions.Configuration;

namespace DEV.Services.Implementations
{
    public class UsersManagementService : IUsersManagementService
    {
        readonly TokenProperties tokenProperties = new TokenProperties();

        public UsersManagementService()
        {
            var settings = ConfigHelper.GetConfig();
            tokenProperties = settings.GetSection("ServiceTokenManagement").Get<TokenProperties>();
        }

        public async Task<LoginResponse> AuthenticateUser(LoginRequest request)
        {
            try
            {
                IUsersManagement usersManagement = UsersManagement.Instance;
                var validUser = await usersManagement.ValidateUser(request);

                if (!validUser.Item1)
                {
                    return new LoginResponse { Authenticated = false };
                }

                ITokenService tokenService = new TokenService();
                var token = tokenService.BuildToken(tokenProperties.SecretKey, tokenProperties.Issuer, validUser.Item2);

                var loginResponse = new LoginResponse
                {
                    Authenticated = validUser.Item1,
                    Message="Datos Correctos",
                    User = validUser.Item2,
                    AuthenticationToken = token
                };

                return loginResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
