using DEV.Entities;

namespace DEV.Services.Interfaces
{
    public interface IUsersManagementService
    {
        Task<LoginResponse> AuthenticateUser(LoginRequest request);
    }
}
