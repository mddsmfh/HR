using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UsersDAO
    {
        private string zfc = "Data Source=.;Initial Catalog=HR;User ID=sa;Password=sasa";
        public async Task<int> SelectAsync(Users users)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $@"SELECT COUNT(*) FROM [dbo].[users]
                        WHERE u_name = '{users.u_name}' AND u_password = '{users.u_password}'";

                int count = await sqlConnection.ExecuteScalarAsync<int>(sql);
                return count;
            }
        }


        public async Task<Users> SelectAsync(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $@"select u_true_name from [dbo].[users] where u_name='{name}'";

                return await sqlConnection.QueryFirstAsync<Users>(sql);
                
            }
        }

        public async Task<Users> SelectAsyncX()
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $@"select u_true_name from [dbo].[users]";

                return await sqlConnection.QueryFirstAsync<Users>(sql);

            }
        }

    }
}
