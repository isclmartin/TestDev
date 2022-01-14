using DEV.Entities;

namespace DEV.Data.Interfaces
{
    public interface IUsersManagement
    {
        Task<Tuple<bool, User>> ValidateUser(LoginRequest loginInfo);
    }
}
