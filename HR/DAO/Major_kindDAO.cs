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
    public class Major_kindDAO
    {
        private string zfc = "Data Source=.;Initial Catalog=HR;User ID=sa;Password=sasa";

        /// <summary>
        /// 进行查询职位所有信息
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Major_kind>> SelectAsync()
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = "select*from[dbo].[config_major_kind]";
                return await sqlConnection.QueryAsync<Major_kind>(sql);
            }
        }




        /// <summary>
        /// 进行添加
        /// </summary>
        /// <param name="Major_kind"></param>
        /// <returns></returns>
        public async Task<int> TianAsync(Major_kind major_Kind)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql1 = "SELECT TOP 1 \r\n    CASE \r\n        WHEN [major_kind_id] + 1 < 10 THEN '0' + CAST([major_kind_id] + 1 AS VARCHAR(2))\r\n        ELSE CAST([major_kind_id] + 1 AS VARCHAR(2))\r\n    END AS FormattedValue\r\nFROM [dbo].[config_major_kind] \r\nORDER BY mfk_id DESC";
                string id = await sqlConnection.QueryFirstAsync<string>(sql1);
                string sql = $@"INSERT INTO [dbo].[config_major_kind](major_kind_id, major_kind_name) 
                                VALUES('{id}','{major_Kind.major_kind_name}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        /// <summary>
        /// 进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> ScAsync(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"DELETE  FROM [dbo].[config_major_kind] WHERE [mfk_id] = '{id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }
    }
}
