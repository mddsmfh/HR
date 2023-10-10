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
    public class Engage_resumeDAO
    {
        private string zfc = "Data Source=.;Initial Catalog=HR;User ID=sa;Password=sasa";
        public async Task<int> TianAsync(Engage_resume resume)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $@"insert into [dbo].[engage_resume](human_major_kind_id,human_major_kind_name,human_major_id,human_major_name,engage_type,human_name,human_sex,human_email,human_telephone,
                human_homephone,human_mobilephone,human_address,human_postcode,human_nationality,human_birthplace,human_birthday,human_race,human_religion,human_party,human_idcard,
                human_age,human_college,human_educated_degree,human_educated_years,human_educated_major,demand_salary_standard,regist_time,human_specility,human_hobby,human_history_records,
                remark,check_status,checker,check_time,human_picture,register)
                values('{resume.human_major_kind_id}','{resume.human_major_kind_name}','{resume.human_major_id}','{resume.human_major_name}','{resume.engage_type}','{resume.human_name}','{resume.human_sex}','{resume.human_email}','{resume.human_telephone}',
                '{resume.human_homephone}','{resume.human_mobilephone}','{resume.human_address}','{resume.human_postcode}','{resume.human_nationality}','{resume.human_birthplace}','{resume.human_birthday}','{resume.human_race}','{resume.human_religion}','{resume.human_party}','{resume.human_idcard}',
                '{resume.human_age}','{resume.human_college}','{resume.human_educated_degree}','{resume.human_educated_years}','{resume.human_educated_major}','{resume.demand_salary_standard}','{resume.regist_time}','{resume.human_specility}','{resume.human_hobby}','{resume.human_history_records}',
                '{resume.remark}','0','{resume.checker}','{resume.check_time}','{resume.human_picture}','{resume.register}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }


        public async Task<int> Xiu(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"UPDATE  [dbo].[engage_resume] SET check_status='1',interview_status='0' WHERE res_id = '{id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        public async Task<int> Xiuss(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"UPDATE  [dbo].[engage_resume] SET interview_status='6' WHERE res_id = '{id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        public async Task<int> Xug(int id,string text)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"UPDATE  [dbo].[engage_resume] SET pass_checkComment='{text}' WHERE res_id = '{id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }
        public async Task<int> Xug2(int id, string text)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"UPDATE  [dbo].[engage_resume] SET pass_passComment='{text}' WHERE res_id = '{id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        public async Task<int> Xiu2(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"UPDATE  [dbo].[engage_resume] SET interview_status='1' WHERE res_id = '{id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        public async Task<int> Xiu2( int zt, int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"UPDATE  [dbo].[engage_resume] SET interview_status='{zt}' WHERE res_id = '{id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }


        public async Task<Engage_resume> ChaYiAsync(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"SELECT * FROM [dbo].[engage_resume] WHERE [res_id] = '{id}'";
                return await sqlConnection.QueryFirstAsync<Engage_resume>(sql);
            }
        }


        public async Task<Fenye<Engage_resume>> SelectAsync(int pageSize, int currentPage,string Zyf,string Zwm,string Gjc,string Djq,string Djz)
        {
            using (SqlConnection connection = new SqlConnection(zfc))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("PageSize", pageSize);
                dynamicParameters.Add("PageNumber", currentPage);
                dynamicParameters.Add("Zyf", Zyf);
                dynamicParameters.Add("Zwm", Zwm);
                dynamicParameters.Add("Gjc", Gjc);
                dynamicParameters.Add("Djq", Djq);
                dynamicParameters.Add("Djz", Djz);
                dynamicParameters.Add("TotalPages", direction: ParameterDirection.Output, dbType: DbType.Int32);

                string sql = "exec engage_resumeFY  @Zyf,@Zwm,@Gjc,@Djq,@Djz,@PageSize, @PageNumber,@TotalPages out";

                var result = await connection.QueryAsync<Engage_resume>(sql, dynamicParameters);

                int totalPages = dynamicParameters.Get<int>("TotalPages");
              
                Fenye<Engage_resume> fenye = new Fenye<Engage_resume>();
                fenye.List = result.ToList();
                fenye.Rows = totalPages;
                return fenye;
            }
        }



        public async Task<Fenye<Engage_resume>> SelectAsync2(int pageSize, int currentPage, string Zyf, string Zwm, string Gjc, string Djq, string Djz)
        {
            using (SqlConnection connection = new SqlConnection(zfc))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("PageSize", pageSize);
                dynamicParameters.Add("PageNumber", currentPage);
                dynamicParameters.Add("Zyf", Zyf);
                dynamicParameters.Add("Zwm", Zwm);
                dynamicParameters.Add("Gjc", Gjc);
                dynamicParameters.Add("Djq", Djq);
                dynamicParameters.Add("Djz", Djz);
                dynamicParameters.Add("TotalPages", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec engage_resumeFY3 @Zyf,@Zwm,@Gjc,@Djq,@Djz,@PageSize,@PageNumber,@TotalPages out";

                var result = await connection.QueryAsync<Engage_resume>(sql, dynamicParameters);

                int totalPages = dynamicParameters.Get<int>("TotalPages");

                Fenye<Engage_resume> fenye = new Fenye<Engage_resume>();
                fenye.List = result.ToList();
                fenye.Rows = totalPages;
                return fenye;
            }
        }



        public async Task<Fenye<Engage_resume>> SelectdAsync(int pageSize, int currentPage)
        {
            using (SqlConnection connection = new SqlConnection(zfc))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("PageSize", pageSize);
                dynamicParameters.Add("PageNumber", currentPage);
                dynamicParameters.Add("TotalPages", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("TotalRows", direction: ParameterDirection.Output, dbType: DbType.Int32);

                string sql = "exec engage_resumeLFY @PageSize, @PageNumber,@TotalPages out,@TotalRows out";

                var result = await connection.QueryAsync<Engage_resume>(sql, dynamicParameters);

                int totalPages = dynamicParameters.Get<int>("TotalPages");
                int totalRows = dynamicParameters.Get<int>("TotalRows");

                Fenye<Engage_resume> fenye = new Fenye<Engage_resume>();
                fenye.List = result.ToList();
                fenye.Rows = totalPages;
                fenye.Rowst = totalRows;
                return fenye;
            }
        }

        public async Task<Fenye<Engage_resume>> SelectSAsync(int pageSize, int currentPage)
        {
            using (SqlConnection connection = new SqlConnection(zfc))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("PageSize", pageSize);
                dynamicParameters.Add("PageNumber", currentPage);
                dynamicParameters.Add("TotalPages", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("TotalRows", direction: ParameterDirection.Output, dbType: DbType.Int32);

                string sql = "exec engage_resumeSFY @PageSize, @PageNumber,@TotalPages out,@TotalRows out";

                var result = await connection.QueryAsync<Engage_resume>(sql, dynamicParameters);

                int totalPages = dynamicParameters.Get<int>("TotalPages");
                int totalRows = dynamicParameters.Get<int>("TotalRows");

                Fenye<Engage_resume> fenye = new Fenye<Engage_resume>();
                fenye.List = result.ToList();
                fenye.Rows = totalPages;
                fenye.Rowst = totalRows;
                return fenye;
            }
        }

        public async Task<Fenye<Engage_resume>> SelectCAsync(int pageSize, int currentPage)
        {
            using (SqlConnection connection = new SqlConnection(zfc))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("PageSize", pageSize);
                dynamicParameters.Add("PageNumber", currentPage);
                dynamicParameters.Add("TotalPages", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("TotalRows", direction: ParameterDirection.Output, dbType: DbType.Int32);

                string sql = "exec engage_resumeCFY @PageSize, @PageNumber,@TotalPages out,@TotalRows out";

                var result = await connection.QueryAsync<Engage_resume>(sql, dynamicParameters);

                int totalPages = dynamicParameters.Get<int>("TotalPages");
                int totalRows = dynamicParameters.Get<int>("TotalRows");

                Fenye<Engage_resume> fenye = new Fenye<Engage_resume>();
                fenye.List = result.ToList();
                fenye.Rows = totalPages;
                fenye.Rowst = totalRows;
                return fenye;
            }
        }



    }
}
