using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebRegistration.BussinessLayer
{
    public class UtilityTools
    {
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["RegistrationDB"].ConnectionString;
        }

        public static int ExecuteInsert(Address address, Registration registration)
        {
            SqlConnection conn;
            SqlCommand cmd;

            using (conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    //string sql = "INSERT INTO Registration (Name, Username, Password) VALUES (@Name,@Username,@Password)";
                    string sql = "sp_InsertRegistrationInfo";

                    conn.Open();
                    using (cmd = new SqlCommand(sql, conn))
                    {

                        SqlParameter[] param = new SqlParameter[9];
                        param[0] = new SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50);
                        param[1] = new SqlParameter("@Username", System.Data.SqlDbType.VarChar, 50);
                        param[2] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar, 50);
                        param[3] = new SqlParameter("@Gender", System.Data.SqlDbType.Char, 6);
                        param[4] = new SqlParameter("@Age", System.Data.SqlDbType.Int, 50);
                        param[5] = new SqlParameter("@StreetNumber", System.Data.SqlDbType.Int, 50);
                        param[6] = new SqlParameter("@StreetName", System.Data.SqlDbType.VarChar, 50);
                        param[7] = new SqlParameter("@City", System.Data.SqlDbType.VarChar, 50);
                        param[8] = new SqlParameter("@PostalCode", System.Data.SqlDbType.Char, 6);

                        param[0].Value = registration.Name;
                        param[1].Value = registration.Username;
                        param[2].Value = registration.Password;
                        param[3].Value = registration.Gender;
                        param[4].Value = registration.Age;
                        param[5].Value = address.StreetNumber;
                        param[6].Value = address.StreetName;
                        param[7].Value = address.City;
                        param[8].Value = address.PostalCode;

                        foreach (SqlParameter p in param)
                        {
                            cmd.Parameters.Add(p);
                        }

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        return (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException ex)
                {
                    return ex.ErrorCode;
                }
            }
        }
    }
}