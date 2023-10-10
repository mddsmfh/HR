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
    public class Engage_interviewDAO
    {
        private string zfc = "Data Source=.;Initial Catalog=HR;User ID=sa;Password=sasa";
        public async Task<Engage_interview> ChaYiAsync(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql1 = $"select count(*) from [dbo].[engage_interview] where [human_name]='{name}'";
                int count = await sqlConnection.ExecuteScalarAsync<int>(sql1);
                if (count > 0)
                {
                    string sql = $"SELECT * FROM [dbo].[engage_interview] WHERE [human_name] = '{name}'";
                    Engage_interview engage = await sqlConnection.QueryFirstAsync<Engage_interview>(sql);
                    return engage;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Engage_interview> ChaIDAsync(int idc)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                    string sql = $"SELECT * FROM [dbo].[engage_interview] WHERE [ein_id] = '{idc}'";
                    Engage_interview engage = await sqlConnection.QueryFirstAsync<Engage_interview>(sql);
                    return engage;
            }
        }


        public async Task<int> TianAsync(Engage_interview interview)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $@"insert into [dbo].[engage_interview](human_name, interview_amount, human_major_kind_id, human_major_kind_name, human_major_id, human_major_name, image_degree, native_language_degree, foreign_language_degree, response_speed_degree, EQ_degree, IQ_degree, multi_quality_degree, register, registe_time, resume_id, interview_comment, interview_status)
                                values('{interview.human_name}', '{interview.interview_amount}', '{interview.human_major_kind_id}', '{interview.human_major_kind_name}', '{interview.human_major_id}', '{interview.human_major_name}', '{interview.image_degree}', '{interview.native_language_degree}', '{interview.foreign_language_degree}', '{interview.response_speed_degree}', '{interview.EQ_degree}', '{interview.IQ_degree}', '{interview.multi_quality_degree}', '{interview.register}', '{interview.registe_time}', '{interview.resume_id}', '{interview.interview_comment}', '{interview.interview_status}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }



        public async Task<Fenye<Engage_interview>> SelectAsync(int pageSize, int currentPage)
        {
            using (SqlConnection connection = new SqlConnection(zfc))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("PageSize", pageSize);
                dynamicParameters.Add("PageNumber", currentPage);
                dynamicParameters.Add("TotalPages", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("TotalRows", direction: ParameterDirection.Output, dbType: DbType.Int32);

                string sql = "exec engage_interviewFY @PageSize, @PageNumber,@TotalPages out,@TotalRows out";

                var result = await connection.QueryAsync<Engage_interview>(sql, dynamicParameters);

                int totalPages = dynamicParameters.Get<int>("TotalPages");
                int totalRows = dynamicParameters.Get<int>("TotalRows");

                Fenye<Engage_interview> fenye = new Fenye<Engage_interview>();
                fenye.List = result.ToList();
                fenye.Rows = totalPages;
                fenye.Rowst = totalRows;
                return fenye;
            }
        }


        public async Task<int> Xiu2(string sxr, int zt, string sxsj, string shenhe, int ids)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"UPDATE [dbo].[engage_interview] SET checker = '{sxr}',interview_status='{zt}',check_time='{sxsj}',result='{shenhe}' WHERE ein_id = '{ids}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        public async Task<Engage_interview> ChaXAsync(int idc)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"select*from[dbo].[engage_interview] where [resume_id]='{idc}'";
                Engage_interview engage = await sqlConnection.QueryFirstAsync<Engage_interview>(sql);
                return engage;
            }
        }


    }
}
