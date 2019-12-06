using System;
using System.Data.SqlClient;

namespace WebRegistration //namespace is same as package in java
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                this.lblResultMessage.Text = "";
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
                if (this.Page.IsValid)
                {
                    int result = ExecuteInsert(this.txtName.Text, this.txtUsername.Text, this.txtPassword.Text, this.ddlGender.SelectedValue, Convert.ToInt32(this.txtAge.Text), Convert.ToInt32(this.txtStreetNumber.Text), this.txtStreetName.Text, this.txtCity.Text, this.TxtPostalCode.Text);

                if (result == 1)
                    this.lblResultMessage.Text = "Successful submition!";
                else if (result == 0)
                    this.lblResultMessage.Text = "There was an error at the Database level";
                else
                    this.lblResultMessage.Text = "There was an error at the Method level";
                

                }
                
            
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["RegistrationDB"].ConnectionString;
        }

        private int ExecuteInsert(string name, string username, string password, string gender, int age, int streetNumber, string streetName, string city, string postalCode)
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

                        param[0].Value = name;
                        param[1].Value = username;
                        param[2].Value = password;
                        param[3].Value = gender;
                        param[4].Value = age;
                        param[5].Value = streetNumber;
                        param[6].Value = streetName;
                        param[7].Value = city;
                        param[8].Value = postalCode;

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