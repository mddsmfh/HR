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
    public class Public_charDAO
    {
        private string zfc = "Data Source=.;Initial Catalog=HR;User ID=sa;Password=sasa";

        /// <summary>
        /// 进行查询公共属性设置所有信息
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Public_char>> SelectAsync()
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = "select*from[dbo].[config_public_char]";
                return await sqlConnection.QueryAsync<Public_char>(sql);
            }
        }

        public async Task<IEnumerable<Public_char>> SelectListAsync(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"select*from [dbo].[config_public_char] where [attribute_kind]='{name}'";
                return await sqlConnection.QueryAsync<Public_char>(sql);
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


        /// <summary>
        /// 进行添加
        /// </summary>
        /// <param name="Public_char"></param>
        /// <returns></returns>
        public async Task<int> TianAsync(Public_char public_Char)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $@"INSERT INTO [dbo].[config_public_char](attribute_kind, attribute_name) 
                                VALUES('{public_Char.attribute_kind}','{public_Char.attribute_name}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }
    }
}
