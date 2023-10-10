using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Major_releaseDAO
    {
        private string zfc = "Data Source=.;Initial Catalog=HR;User ID=sa;Password=sasa";


        public async Task<Fenye<Major_release>> SelectAsync(int pageSize, int currentPage)
        {
            using (SqlConnection connection = new SqlConnection(zfc))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("PageSize", pageSize);
                dynamicParameters.Add("PageNumber", currentPage);
                dynamicParameters.Add("TotalPages", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("TotalRows", direction: ParameterDirection.Output, dbType: DbType.Int32);

                string sql = "exec EMRBG @PageSize, @PageNumber,@TotalPages out,@TotalRows out"; 

                var result = await connection.QueryAsync<Major_release>(sql,dynamicParameters);

                int totalPages = dynamicParameters.Get<int>("TotalPages");
                int totalRows = dynamicParameters.Get<int>("TotalRows");

                Fenye<Major_release> fenye = new Fenye<Major_release>();
                fenye.List = result.ToList();
                fenye.Rows = totalPages;
                fenye.Rowst = totalRows;
                return fenye;
            }
        }



        public async Task<Major_release> ChaYiAsync(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"SELECT * FROM [dbo].[engage_major_release] WHERE [mre_id] = '{id}'";
                return await sqlConnection.QueryFirstAsync<Major_release>(sql);
            }
        }

        public async Task<int> Xiu(Major_release major_Release)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $@"UPDATE  [dbo].[engage_major_release] 
                                SET engage_type = '{major_Release.engage_type}', human_amount = '{major_Release.human_amount}', deadline = '{major_Release.deadline}', changer = '{major_Release.changer}',
                                change_time = '{major_Release.change_time}', major_describe = '{major_Release.major_describe}', engage_required = '{major_Release.engage_required}'
                                WHERE mre_id = '{major_Release.mre_id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }


        public async Task<int> ScAsync(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"DELETE  FROM [dbo].[engage_major_release] WHERE [mre_id] = '{id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }




        /// <summary>
        /// 进行添加
        /// </summary>
        /// <param name="Major_release"></param>
        /// <returns></returns>
        public async Task<int> TianAsync(Major_release major)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                  string sql = $@"insert into [dbo].[engage_major_release]
                  (first_kind_id, first_kind_name, second_kind_id, second_kind_name, third_kind_id, third_kind_name, major_kind_id, major_kind_name, 
                  major_id, major_name, human_amount, engage_type, deadline, register, regist_time, major_describe, engage_required)
                  values({major.first_kind_id},'{major.first_kind_name}','{major.second_kind_id}','{major.second_kind_name}','{major.third_kind_id}',
                   '{major.third_kind_name}','{major.major_kind_id}','{major.major_kind_name}','{major.major_id}','{major.major_name}','{major.human_amount}','{major.engage_type}','{major.deadline}','{major.register}',
                    '{major.regist_time}','{major.major_describe}','{major.engage_required}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }
    }
}
