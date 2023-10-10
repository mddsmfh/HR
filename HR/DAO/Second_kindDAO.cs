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
    public class Second_kindDAO
    {
        private string zfc = "Data Source=.;Initial Catalog=HR;User ID=sa;Password=sasa";

        /// <summary>
        /// 进行查询二级所有信息
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Second_kind>> SelectAsync()
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = "select*from[dbo].[config_file_second_kind]";
                return await sqlConnection.QueryAsync<Second_kind>(sql);
            }
        }


        public async Task<IEnumerable<Second_kind>> SelectListAsync(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"select*from[dbo].[config_file_second_kind] where first_kind_name='{name}'";
                return await sqlConnection.QueryAsync<Second_kind>(sql);
            }
        }

        /// <summary>
        /// 进行添加
        /// </summary>
        /// <param name="first_Kind"></param>
        /// <returns></returns>
        public async Task<int> TianAsync(Second_kind second_Kind)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql1 = "SELECT TOP 1 \r\n    CASE \r\n        WHEN [second_kind_id] + 1 < 10 THEN '0' + CAST([second_kind_id] + 1 AS VARCHAR(2))\r\n        ELSE CAST([second_kind_id] + 1 AS VARCHAR(2))\r\n    END AS FormattedValue\r\nFROM [dbo].[config_file_second_kind] \r\nORDER BY fsk_id DESC";
                string id = await sqlConnection.QueryFirstAsync<string>(sql1);
                string sql = $@"INSERT INTO [dbo].[config_file_second_kind](first_kind_id, first_kind_name, second_kind_id, second_kind_name, second_salary_id, second_sale_id) 
                                VALUES('{second_Kind.first_kind_id}','{second_Kind.first_kind_name}','{id}','{second_Kind.second_kind_name}','{second_Kind.second_salary_id}','{second_Kind.second_sale_id}')";
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
                string sql = $"DELETE  FROM [dbo].[config_file_second_kind] WHERE [fsk_id] = '{id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        /// <summary>
        /// 进行查询具体一个信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Second_kind> ChaYiAsync(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"SELECT * FROM [dbo].[config_file_second_kind] WHERE [fsk_id] = '{id}'";
                return await sqlConnection.QueryFirstAsync<Second_kind>(sql);
            }
        }

        public async Task<int> Xiu(Second_kind second_Kind)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"UPDATE  [dbo].[config_file_second_kind] SET second_salary_id = '{second_Kind.second_salary_id}',second_sale_id='{second_Kind.second_sale_id}' WHERE second_kind_id = '{second_Kind.second_kind_id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }




    }
}
