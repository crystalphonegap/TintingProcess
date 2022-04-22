using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ShadeCard
{
    public partial class AddEmployees : System.Web.UI.Page
    {
        private SqlCommand cmd;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindRole();
                    lblId.Text = Session["EmployeeId"].ToString();
                    string Status = Session["Emptatus"].ToString();

                    BindDetails();
                    if (Status == "View")
                    {
                        txtAddress.ReadOnly = true;
                        txtEmail.ReadOnly = true;
                        txtEmpCode.ReadOnly = true;
                        txtEmpName.ReadOnly = true;
                        txtMobile.ReadOnly = true;
                        txtPassword.ReadOnly = true;
                        txtPosition.ReadOnly = true;
                        btnAdd.Visible = false;

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            INSERTUPDATEEMPLOYEES();
        }
        protected void INSERTUPDATEEMPLOYEES()
        {
            con.Open();
            try
            {


                cmd = new SqlCommand("PRC_MS_EMPLOYEE_IUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ID", lblId.Text);
                cmd.Parameters.AddWithValue("@P_EMPLOYEECODE", txtEmpCode.Text.Trim());
                cmd.Parameters.AddWithValue("@P_EMPLOYEENAME", txtEmpName.Text.Trim());
                cmd.Parameters.AddWithValue("@P_TYPE", dropType.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@P_EMAIL", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@P_MOBILE", txtMobile.Text.Trim());
                cmd.Parameters.AddWithValue("@P_POSITION", txtPosition.Text.Trim());
                cmd.Parameters.AddWithValue("@P_PASSWORD", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@P_STATUS", DropStatus.SelectedValue);
                cmd.Parameters.AddWithValue("@P_ADDEDBY", Session["Id"].ToString());
                cmd.Parameters.AddWithValue("@P_ADDRESS", txtAddress.Text);
                if (lblId.Text == "" || lblId.Text == "0" || lblId.Text == null)
                {
                    cmd.Parameters.AddWithValue("@P_ACTION", "I");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@P_ACTION", "U");
                }

                cmd.Parameters.Add("@P_MESSAGES", SqlDbType.VarChar, 300);
                cmd.Parameters["@P_MESSAGES"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@P_EMPLOYEE_TYPE_ID", dropType.SelectedValue);
                cmd.ExecuteNonQuery();
                string Messages = cmd.Parameters["@P_MESSAGES"].Value.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Messages + "');window.location ='ViewEmployees.aspx';", true);
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();

            }


        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["EmployeeId"] = null;
            Session["Emptatus"] = null;
            Response.Redirect("ViewEmployees.aspx");
        }
        protected void BindDetails()
        {

            try
            {

                con.Open();
                cmd = new SqlCommand("PRC_MS_GETEMPLOYEES", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ID", lblId.Text);
                cmd.Parameters.AddWithValue("@P_PAGESIZE", 1);
                cmd.Parameters.AddWithValue("@P_PAGENO", 10);
                cmd.Parameters.AddWithValue("@P_ACTION", "SINGLE");
                cmd.Parameters.AddWithValue("@P_KEYWORD", "");

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    txtAddress.Text = dt.Rows[0]["ADDRESS"].ToString();
                    txtEmpCode.Text = dt.Rows[0]["EMPLOYEE_CODE"].ToString();
                    txtEmpName.Text = dt.Rows[0]["EMPLOYEE_NAME"].ToString();
                    txtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
                    txtMobile.Text = dt.Rows[0]["MOBILE"].ToString();
                    txtPosition.Text = dt.Rows[0]["POSITION_NO"].ToString();
                    txtPassword.Text = dt.Rows[0]["PASSWORD"].ToString();
                    DropStatus.Items.FindByValue(dt.Rows[0]["STATUS"].ToString()).Selected = true;
                    dropType.Items.FindByValue(dt.Rows[0]["EMPLOYEE_TYPE_ID"].ToString()).Selected = true;
                }
                else
                {

                }
            }
            catch (SqlException Ex)
            {

            }
            finally
            {
                con.Close();
            }

        }

        protected void btnSaveRole_Click(object sender, EventArgs e)
        {
            if (txtUserRole.Text != "")
            {


                con.Open();
                try
                {
                    cmd = new SqlCommand("PRC_MS_USERROLE_IUD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_ID", 0);
                    cmd.Parameters.AddWithValue("@P_ROLE", txtUserRole.Text.Trim());
                    cmd.Parameters.AddWithValue("@P_USERID", Session["Id"].ToString());
                    cmd.Parameters.AddWithValue("@P_USERNAME", Session["UserName"].ToString());
                    cmd.Parameters.Add("@P_MESSAGE", SqlDbType.VarChar, 300);
                    cmd.Parameters["@P_MESSAGE"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@P_ACTION", "I");
                    cmd.ExecuteNonQuery();
                    string Message = cmd.Parameters["@P_MESSAGE"].Value.ToString();
                    AlertMessage(Message);
                    txtUserRole.Text = "";
                }
                catch (SqlException ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), " alert('Please Enter The User Role');", true);
            }
            BindRole();
        }

        public void AlertMessage(string message)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), " alert('" + message + "');", true);
        }

        protected void BindRole()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_MS_BINDDROPDOWN_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_TYPE", "ROLE");
                cmd.Parameters.AddWithValue("@P_DIVISION", "0");
                cmd.Parameters.AddWithValue("@P_GORUP", "0");
                cmd.Parameters.AddWithValue("@P_MATERIALCODE", "0");
                dropType.DataSource = cmd.ExecuteReader();
                dropType.DataTextField = "NAME";
                dropType.DataValueField = "CODE";
                dropType.DataBind();

                dropType.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
    }
}