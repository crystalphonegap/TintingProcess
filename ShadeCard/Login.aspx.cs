using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Product_Work_Flow
{
    public partial class Login : System.Web.UI.Page
    {
      private SqlCommand cmd;
      static  SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void kt_login_forgot_cancel2_Click(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            checklogin();
           
        }

        public void checklogin()
        {
            con.Open();
            try
            {

           
            cmd = new SqlCommand("PRC_MS_LOGIN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_USECODE", txtUsercode.Text.Trim());
            cmd.Parameters.AddWithValue("@P_PASSWORD", txtPassword.Text.Trim());
            cmd.Parameters.Add("@P_MESSAGE", SqlDbType.VarChar, 300);
            cmd.Parameters["@P_MESSAGE"].Direction = ParameterDirection.Output;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            
                DataTable dt = new DataTable();
                sda.Fill(dt);
                string Messages = cmd.Parameters["@P_MESSAGE"].Value.ToString();
                if (Messages != "INVALID CREDENTIALS")
                {
                    Session["UserCode"] = dt.Rows[0]["EMPLOYEE_CODE"].ToString();
                    Session["UserName"] = dt.Rows[0]["EMPLOYEE_NAME"].ToString();
                    Session["UserType"] = dt.Rows[0]["EMPLOYEE_TYPE"].ToString();
                    Session["UserEmail"] = dt.Rows[0]["EMAIL"].ToString();
                    Session["Id"] = dt.Rows[0]["Id"].ToString();
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    AlertMessage(Messages);
                }
         
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }


        public void AlertMessage(string message)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), " alert('" + message + "');", true);
        }
    }
}