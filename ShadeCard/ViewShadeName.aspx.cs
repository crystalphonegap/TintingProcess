using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using ClosedXML.Excel;
using System.IO;

namespace ShadeCard
{
    public partial class ViewShadeName : System.Web.UI.Page
    {
        private SqlCommand cmd, cmd2;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid(1, 15);
            }
        }

        protected void bindGrid(int PageNumber, int PageSize)
        {
            cmd = new SqlCommand("PRC_MS_GETSHDAENAME_LIST", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_ID", 0);
            cmd.Parameters.AddWithValue("@P_PAGENO", PageNumber);
            cmd.Parameters.AddWithValue("@P_PAGESIZE", PageSize);
            cmd.Parameters.AddWithValue("@P_ACTION", "All");
            cmd.Parameters.AddWithValue("@P_KEYWORD", txtShadeCode.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gvShadeCard.DataSource = dt;
                gvShadeCard.DataBind();

            }
            else
            {
                gvShadeCard.DataSource = null;
                gvShadeCard.DataBind();

            }


        }


        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindGrid(1, 15);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddShadeName.aspx");
        }

        protected void DropStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindGrid(1, 15);
        }

        protected void gvShadeCard_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();
            if (e.CommandName == "View")
            {
                Session["SHADENAMEID"] = Id;
                Session["SHADENAMEVIEW"] = "View";
                Response.Redirect("AddShadeName.aspx");
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindGrid(1, 15);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("PRC_MS_GETSHDAENAME_LIST", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_ID", 0);
            cmd.Parameters.AddWithValue("@P_PAGENO", 1);
            cmd.Parameters.AddWithValue("@P_PAGESIZE", 15);
            cmd.Parameters.AddWithValue("@P_ACTION", "AllLIST");
            cmd.Parameters.AddWithValue("@P_KEYWORD", txtShadeCode.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "ShadeList");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Now.Date.ToString("dd/MM/yyyy") + "ApproveList.xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No Records Found.....!');window.location ='ShadeListForMDC.aspx';", true);
            }
        }

        protected void gvShadeCard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShadeCard.PageIndex = e.NewPageIndex;
            bindGrid(1, 15);
        }

        protected void gvShadeCard_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}