using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebRegistration
{
    public partial class RegistrationsList2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                DataTable registration = ((DataSet)BussinessLayer.UtilityTools.ExecuteSelect()).Tables[0];
                DataTable address = ((DataSet)BussinessLayer.UtilityTools.ExecuteSelect()).Tables[1];

                this.DropDownList1.DataSource = registration;
                this.DropDownList1.DataTextField = registration.Columns[1].ToString();
                this.DropDownList1.DataValueField = registration.Columns[2].ToString();
                this.DropDownList1.DataBind(); //method of databinding 

                this.DropDownList2.DataSource = address;
                this.DropDownList2.DataTextField = address.Columns[1].ToString();
                this.DropDownList2.DataValueField = address.Columns[2].ToString();
                this.DropDownList2.DataBind(); //method of databinding 
            }
        }
    }
}