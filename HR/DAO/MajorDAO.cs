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
    public class MajorDAO
    {
        private string zfc = "Data Source=.;Initial Catalog=HR;User ID=sa;Password=sasa";

        /// <summary>
        /// 进行查询职称所有信息
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Public_char>> SelectAsync()
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = "select*from[dbo].[config_public_char] where attribute_kind='职称'";
                return await sqlConnection.QueryAsync<Public_char>(sql);
            }
        }

        public async Task<IEnumerable<Major>> SelectsAsync()
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = "select*from[dbo].[config_major]";
                return await sqlConnection.QueryAsync<Major>(sql);
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
                string sql = $"DELETE  FROM [dbo].[config_public_char] WHERE [pbc_id] = '{id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        public async Task<int> ScAsyncs(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"DELETE  FROM [dbo].[config_major] WHERE [mak_id] = '{id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }


        /// <summary>
        /// 进行添加
        /// </summary>
        /// <param name="Major"></param>
        /// <returns></returns>
        public async Task<int> TianAsync(Major major)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $@"INSERT INTO [dbo].[config_major](major_kind_id, major_kind_name, major_id, major_name, test_amount) 
                                VALUES('{major.major_kind_id}','{major.major_kind_name}','{major.major_id}','{major.major_name}',0)";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }



        public async Task<IEnumerable<Major>> SelectListAsync(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"select*from[dbo].[config_major] where major_kind_name='{name}'";
                return await sqlConnection.QueryAsync<Major>(sql);
            }
        }

    }
}
