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
    public class Third_kindDAO
    {
        private string zfc = "Data Source=.;Initial Catalog=HR;User ID=sa;Password=sasa";

        /// <summary>
        /// 进行查询三级所有信息
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Third_kind>> SelectAsync()
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = "select*from[dbo].[config_file_third_kind]";
                return await sqlConnection.QueryAsync<Third_kind>(sql);
            }
        }

        public async Task<IEnumerable<Third_kind>> SelectListAsync(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"select*from[dbo].[config_file_third_kind] where second_kind_name='{name}'";
                return await sqlConnection.QueryAsync<Third_kind>(sql);
            }
        }


        /// <summary>
        /// 进行添加
        /// </summary>
        /// <param name="third_Kind"></param>
        /// <returns></returns>
        public async Task<int> TianAsync(Third_kind third_Kind)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql1 = "SELECT TOP 1 \r\n    CASE \r\n        WHEN [third_kind_id] + 1 < 10 THEN '0' + CAST([third_kind_id] + 1 AS VARCHAR(2))\r\n        ELSE CAST([third_kind_id] + 1 AS VARCHAR(2))\r\n    END AS FormattedValue\r\nFROM [dbo].[config_file_third_kind] \r\nORDER BY ftk_id DESC";
                string id = await sqlConnection.QueryFirstAsync<string>(sql1);
                string sql = $@"INSERT INTO [dbo].[config_file_third_kind](first_kind_id, first_kind_name, second_kind_id, second_kind_name, third_kind_id, third_kind_name, third_kind_sale_id, third_kind_is_retail) 
                                VALUES('{third_Kind.first_kind_id}','{third_Kind.first_kind_name}','{third_Kind.second_kind_id}','{third_Kind.second_kind_name}','{id}','{third_Kind.third_kind_name}','{third_Kind.third_kind_sale_id}','{third_Kind.third_kind_is_retail}')";
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
                string sql = $"DELETE  FROM [dbo].[config_file_third_kind] WHERE [ftk_id] = '{id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        /// <summary>
        /// 进行查询具体一个信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Third_kind> ChaYiAsync(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"SELECT * FROM [dbo].[config_file_third_kind] WHERE [ftk_id] = '{id}'";
                return await sqlConnection.QueryFirstAsync<Third_kind>(sql);
            }
        }

        public async Task<int> Xiu(Third_kind third_Kind)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"UPDATE  [dbo].[config_file_third_kind] SET third_kind_sale_id = '{third_Kind.third_kind_sale_id}',third_kind_is_retail='{third_Kind.third_kind_is_retail}' WHERE third_kind_id = '{third_Kind.third_kind_id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }


    }
}
