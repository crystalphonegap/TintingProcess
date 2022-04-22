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
    public partial class ViewEmployees : System.Web.UI.Page
    {
        private SqlCommand cmd;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGV(1,10);
            }
        }


        protected void BindGV(int PageNumber, int PageSize)
        {

            try
            {

                con.Open();
                cmd = new SqlCommand("PRC_MS_GETEMPLOYEES", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ID", 0);
                cmd.Parameters.AddWithValue("@P_PAGESIZE", PageSize);
                cmd.Parameters.AddWithValue("@P_PAGENO", PageNumber);
                cmd.Parameters.AddWithValue("@P_ACTION", "All");
                cmd.Parameters.AddWithValue("@P_KEYWORD", txtSearch.Text);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    gvEmployees.DataSource = dt;
                    gvEmployees.DataBind();
                }
                else
                {
                    gvEmployees.DataSource = null;
                    gvEmployees.DataBind();
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

        protected void gvEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
            }
        }

        protected void gvEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();
            if (e.CommandName == "Edit")
            {
                Session["EmployeeId"] = Id;
                Session["Emptatus"] = "Edit";
                Response.Redirect("AddEmployees.aspx");
            }
            else if (e.CommandName == "View")
            {
                Session["EmployeeId"] = Id;
                Session["Emptatus"] = "View";
                Response.Redirect("AddEmployees.aspx");
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindGV(1, 10);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployees.aspx");
        }

        protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployees.PageIndex = e.NewPageIndex;
            BindGV(1, 15);
        }
    }
}