using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Web.UI.HtmlControls;

namespace ShadeCard
{
    public partial class ViewColorants : System.Web.UI.Page
    {
        private SqlCommand cmd;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGV(1, 15);
            }
        }

        protected void BindGV(int PageNumber, int PageSize)
        {

            try
            {

                con.Open();
                cmd = new SqlCommand("PRC_MS_GETCOLORANTS", con);
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
                    gvColorants.DataSource = dt;
                    gvColorants.DataBind();
                }
                else
                {
                    gvColorants.DataSource = null;
                    gvColorants.DataBind();

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

    

      

        protected void gvColorants_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ColorCode = (e.Row.FindControl("lblHexa1") as Label).Text;
                //(e.Row.FindControl("lblHexa") as Label).BackColor= System.Drawing.ColorTranslator.FromHtml(ColorCode);
                //(e.Row.FindControl("lblHexa") as Label).ForeColor = System.Drawing.ColorTranslator.FromHtml(ColorCode);
                TableCell cell = e.Row.Cells[1];
                cell.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCode);
            }
        }

        protected void gvColorants_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();
            if (e.CommandName == "Edit")
            {
                Session["ColorantId"] = Id;
                Session["ViewStatus"] = "Edit";
                Response.Redirect("AddColorants.aspx");
            }
            else if(e.CommandName== "View")
            {
                Session["ColorantId"] = Id;
                Session["ViewStatus"] = "View";
                Response.Redirect("AddColorants.aspx");
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindGV(1, 15);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddColorants.aspx");
        }

        protected void gvColorants_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvColorants_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvColorants.PageIndex = e.NewPageIndex;
            BindGV(1, 15);
        }
    }
}