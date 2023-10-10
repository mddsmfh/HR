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
    public class Human_fileDAO
    {
        private string zfc = "Data Source=.;Initial Catalog=HR;User ID=sa;Password=sasa";
        public async Task<int> TianAsync(Human_file human)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $@"insert into [dbo].[human_file](first_kind_id,first_kind_name,second_kind_id,second_kind_name,third_kind_id,third_kind_name,human_major_kind_id,human_major_kind_name
                            ,human_major_id,hunma_major_name,human_pro_designation,human_name,human_sex,human_email,human_telephone,human_qq,human_mobilephone,human_address,human_postcode
                            ,human_nationality,human_birthplace,human_birthday,human_race,human_religion,human_party,human_id_card,human_society_security_id,human_age,human_educated_degree
                            ,human_educated_years,human_educated_major,salary_standard_id,salary_standard_name,human_bank,human_account,register,regist_time,human_speciality,human_hobby
                            ,human_histroy_records,human_family_membership,remark,human_id,human_picture,checker,check_time,check_status) values('{human.first_kind_id}','{human.first_kind_name}','{human.second_kind_id}','{human.second_kind_name}',
                            '{human.third_kind_id}','{human.third_kind_name}','{human.human_major_kind_id}','{human.human_major_kind_name}'
                            ,'{human.human_major_id}','{human.hunma_major_name}','{human.human_pro_designation}','{human.human_name}','{human.human_sex}','{human.human_email}','{human.human_telephone}','{human.human_qq}'
                            ,'{human.human_mobilephone}','{human.human_address}','{human.human_postcode}'
                            ,'{human.human_nationality}','{human.human_birthplace}','{human.human_birthday}','{human.human_race}','{human.human_religion}','{human.human_party}','{human.human_id_card}','{human.human_society_security_id}','{human.human_age}','{human.human_educated_degree}'
                            ,'{human.human_educated_years}','{human.human_educated_major}','{human.salary_standard_id}','{human.salary_standard_name}','{human.human_bank}','{human.human_account}','{human.register}','{human.regist_time}','{human.human_speciality}','{human.human_hobby}'
                            ,'{human.human_histroy_records}','{human.human_family_membership}','{human.remark}','{human.human_id}','{human.human_picture}','{human.checker}','{human.check_time}','{human.check_status}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        public async Task<Fenye<Human_file>> SelectdAsync(int pageSize, int currentPage)
        {
            using (SqlConnection connection = new SqlConnection(zfc))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("PageSize", pageSize);
                dynamicParameters.Add("PageNumber", currentPage);
                dynamicParameters.Add("TotalPages", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("TotalRows", direction: ParameterDirection.Output, dbType: DbType.Int32);

                string sql = "exec Human_fileFY @PageSize, @PageNumber,@TotalPages out,@TotalRows out";

                var result = await connection.QueryAsync<Human_file>(sql, dynamicParameters);

                int totalPages = dynamicParameters.Get<int>("TotalPages");
                int totalRows = dynamicParameters.Get<int>("TotalRows");

                Fenye<Human_file> fenye = new Fenye<Human_file>();
                fenye.List = result.ToList();
                fenye.Rows = totalPages;
                fenye.Rowst = totalRows;
                return fenye;
            }
        }


        public async Task<Human_file> ChaYiAsync(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"SELECT * FROM [dbo].[Human_file] WHERE [huf_id] = '{id}'";
                return await sqlConnection.QueryFirstAsync<Human_file>(sql);
            }
        }

        public async Task<int> Xiuss(int id,string time)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"UPDATE  [dbo].[Human_file] SET check_status='1',check_time='{time}' WHERE huf_id = '{id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }


        public async Task<Fenye<Human_file>> SelectListAsync(string yi,string er,string sa,string fl,string mc,string qsj,string zsj,int pageSize, int currentPage)
        {
            using (SqlConnection connection = new SqlConnection(zfc))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("IJ", yi);
                dynamicParameters.Add("IIJ", er);
                dynamicParameters.Add("IIIJ", sa);
                dynamicParameters.Add("FL", fl);
                dynamicParameters.Add("ZWEI", mc);
                dynamicParameters.Add("QSJ", qsj);
                dynamicParameters.Add("ZSJ", zsj);
                dynamicParameters.Add("PageSize", pageSize);
                dynamicParameters.Add("PageNumber", currentPage);
                dynamicParameters.Add("TotalPages", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("TotalRow", direction: ParameterDirection.Output, dbType: DbType.Int32);

                string sql = "exec human_fileMCX @IJ, @IIJ, @IIIJ,@FL,@ZWEI,@QSJ,@ZSJ,@PageSize,@PageNumber,@TotalPages out,@TotalRow out";

                var result = await connection.QueryAsync<Human_file>(sql, dynamicParameters);

                int totalPages = dynamicParameters.Get<int>("TotalPages");
                int totalRows = dynamicParameters.Get<int>("TotalRow");

                Fenye<Human_file> fenye = new Fenye<Human_file>();
                fenye.List = result.ToList();
                fenye.Rows = totalPages;
                fenye.Rowst = totalRows;
                return fenye;
            }
        }


        public async Task<Human_file> ChaYiidAsync(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"SELECT * FROM [dbo].[human_file] WHERE [huf_id] = '{id}'";
                return await sqlConnection.QueryFirstAsync<Human_file>(sql);
            }
        }


        public async Task<int> XiuList(Human_file human)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $@"update [dbo].[human_file] set human_pro_designation='{human.human_pro_designation}',human_name='{human.human_name}',human_sex='{human.human_sex}',human_email='{human.human_email}',human_telephone='{human.human_telephone}',human_qq='{human.human_qq}',
                                human_mobilephone = '{human.human_mobilephone}',human_address = '{human.human_address}',human_postcode = '{human.human_postcode}',human_nationality = '{human.human_nationality}',human_birthplace = '{human.human_birthplace}',human_birthday = '{human.human_birthday}',human_race = '{human.human_race}',
                                human_religion = '{human.human_religion}',human_party = '{human.human_party}',human_id_card = '{human.human_id_card}',human_society_security_id = '{human.human_society_security_id}',human_age = '{human.human_age}',human_educated_degree = '{human.human_educated_degree}',human_educated_years = '{human.human_educated_years}',
                                human_educated_major = '{human.human_educated_major}',salary_standard_name = '{human.salary_standard_name}',human_bank = '{human.human_bank}',human_account = '{human.human_account}',human_speciality = '{human.human_speciality}',human_hobby = '{human.human_hobby}',human_histroy_records = '{human.human_histroy_records}',
                                human_family_membership = '{human.human_family_membership}',remark = '{human.remark}' where huf_id = '{human.huf_id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }


    }
}
