using Dapper;
using DEV.Data.Interfaces;
using DEV.Data.Resources;
using DEV.Entities;
using System.Data;
using System.Data.SqlClient;

namespace DEV.Data.Implementations
{
    public class UsersManagement : IUsersManagement
    {
        const string cnn = "DBConnection";
        private static UsersManagement _instance;

        private UsersManagement() { }

        public static UsersManagement Instance => _instance ??= new UsersManagement();

        public SqlConnection ConnectionDb { get; set; }

        public async Task<Tuple<bool, User>> ValidateUser(LoginRequest loginInfo)
        {
            try
            {
                if (loginInfo.UserName.Equals("test") && loginInfo.Password.Equals("test"))
                {
                    return new Tuple<bool, User>(true, new User
                    {
                        Email = "lmac.@tuta.io",
                        LastName = "Antonio Cortéz",
                        Name = "Luis Martin",
                        UserName = "lmac",
                        Roles = new List<Role>
                    {
                        new Role
                        {
                            RoleDescription="Administrador",
                            RoleId="1",
                            RoleName="Administrador"
                        }
                    }
                    });
                }
                else
                {
                    return new Tuple<bool, User>(false, new User());
                }
                
                //using (ConnectionDb = ConnectionFactory.GetConnection(cnn))
                //{
                //    var queryResult = await ConnectionDb.QueryMultipleAsync("usp_ValidateAccess", loginInfo, commandType: CommandType.StoredProcedure);
                //    var users = await queryResult.ReadAsync<User>();
                //    var roles = await queryResult.ReadAsync<Role>();

                //    ConnectionFactory.CloseConnection(ConnectionDb);

                //    if (!users.Any())
                //    {
                //        return new Tuple<bool, User>(false, new User());
                //    }

                //    var result = users.FirstOrDefault();
                //    result.Roles = roles.ToList();

                //    return new Tuple<bool, User>(users.Any(), result);
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
