using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebRegistration //namespace is same as package in java
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label1.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
                if (this.Page.IsValid)
                {
                ExecuteInsert(this.TextBox4.Text, this.TextBox2.Text, this.TextBox3.Text);
                this.Label1.Text = "Thank you for your submission";
            }
                
            
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["RegistrationDB"].ConnectionString;
        }

        private void ExecuteInsert(string name, string username, string password)
        {
            SqlConnection conn;

            using (conn = new SqlConnection(GetConnectionString()))
            {
                try
                { 
                    string sql = "INSERT INTO Registration (Name, Username, Password) VALUES (@Name,@Username,@Password)";

                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50);
                    param[1] = new SqlParameter("@Username", System.Data.SqlDbType.VarChar, 50);
                    param[2] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar, 50);

                    param[0].Value = name;
                    param[1].Value = username;
                    param[2].Value = password;

                    foreach (SqlParameter p in param)
                    {
                        cmd.Parameters.Add(p);
                    }

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                catch(SqlException ex)
                {
                    Response.Write(ex);
                }

            }
        }
    }
}