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
    public class First_kindDAO
    {
        private string zfc = "Data Source=.;Initial Catalog=HR;User ID=sa;Password=sasa";

        /// <summary>
        /// 进行查询一级所有信息
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<First_kind>> ChaYiAsync()
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = "SELECT * FROM [dbo].[config_file_first_kind]";
                return await sqlConnection.QueryAsync<First_kind>(sql);
            }
        }

        /// <summary>
        /// 进行添加
        /// </summary>
        /// <param name="first_Kind"></param>
        /// <returns></returns>
        public async Task<int> TianAsync(First_kind first_Kind)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql1 = "SELECT TOP 1 \r\n    CASE \r\n        WHEN [first_kind_id] + 1 < 10 THEN '0' + CAST([first_kind_id] + 1 AS VARCHAR(2))\r\n        ELSE CAST([first_kind_id] + 1 AS VARCHAR(2))\r\n    END AS FormattedValue\r\nFROM [dbo].[config_file_first_kind] \r\nORDER BY ffk_id DESC";
                string id = await sqlConnection.QueryFirstAsync<string>(sql1);
                string sql = $"INSERT INTO [dbo].[config_file_first_kind]( first_kind_id, first_kind_name, first_kind_salary_id, first_kind_sale_id) VALUES ('{id}','{first_Kind.first_kind_name}','{first_Kind.first_kind_salary_id}','{first_Kind.first_kind_sale_id}')";
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
                string sql = $"DELETE  FROM [dbo].[config_file_first_kind] WHERE [ffk_id] = '{id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        /// <summary>
        /// 进行查询具体一个信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<First_kind> ChaYiAsync(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"SELECT * FROM [dbo].[config_file_first_kind] WHERE [ffk_id] = '{id}'";
                return await sqlConnection.QueryFirstAsync<First_kind>(sql);
            }
        }

        public async Task<int> Xiu(First_kind first_Kind)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"UPDATE  [dbo].[config_file_first_kind] SET first_kind_salary_id = '{first_Kind.first_kind_salary_id}',first_kind_sale_id='{first_Kind.first_kind_sale_id}' WHERE first_kind_id = '{first_Kind.first_kind_id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }



    }
}
