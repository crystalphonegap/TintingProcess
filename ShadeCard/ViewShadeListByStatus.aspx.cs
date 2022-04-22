using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ClosedXML.Excel;
using System.IO;

namespace ShadeCard
{
    public partial class ViewShadeListByStatus : System.Web.UI.Page
    {
        private SqlCommand cmd, cmd2;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                bindGrid(1, 15);
            }
        }

        protected void bindGrid(int PageNumber, int PageSize)
        {
            string status = Session["APSTATUS"].ToString();
            cmd = new SqlCommand("PRC_MS_GETSHADELISTBY_STATUS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_ID", 0);
            cmd.Parameters.AddWithValue("@P_PAGENO", PageNumber);
            cmd.Parameters.AddWithValue("@P_PAGESIZE", PageSize);
            cmd.Parameters.AddWithValue("@P_KEYWORD", txtShadeCode.Text);
            cmd.Parameters.AddWithValue("@P_STATUS", status);
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

        protected void LinkView_Click(object sender, EventArgs e)
        {
            Session["APSTATUS"] = null;
            Response.Redirect("Dashboard.aspx");
        }

        protected void linkview_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ViewShadeCardDetails.aspx");
        }


        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindGrid(1, 15);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddShadeCard.aspx");
        }

        protected void DropStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindGrid(1, 15);
        }

        protected void gvShadeCard_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Session["SHADEHEADERID"] = null;
            Session["EDITSHADEHEADERID"] = null;
            
            string Id = e.CommandArgument.ToString();
            if (e.CommandName == "View")
            {
                if (Session["UserType"].ToString() == "APPROVER")
                {
                    Session["APPROVESHADEID"] = Id;
                    Response.Redirect("ShadeApproveDeatils.aspx");
                }
                else
                {
                    Session["SHADEHEADERID"] = Id;
                    Response.Redirect("ViewShadeCardDetails.aspx");
                }
                
            }
            else if (e.CommandName == "Edit")
            {
                Session["EDITSHADEHEADERID"] = Id;
                Response.Redirect("EditShadeCardDetails.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindGrid(1, 15);
        }

        protected void gvShadeCard_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvShadeCard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShadeCard.PageIndex = e.NewPageIndex;
            bindGrid(1, 15);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("PRC_EXPORT_DATA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_KEYWORD", txtShadeCode.Text);
            cmd.Parameters.AddWithValue("@P_STATUS", Session["APSTATUS"].ToString());
            cmd.Parameters.AddWithValue("@P_FROMDATE", Convert.ToDateTime(txtFromDate.Text));
            cmd.Parameters.AddWithValue("@P_TODATE", Convert.ToDateTime(txtToDate.Text));
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
                    Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Now.Date.ToString("dd/MM/yyyy") + "SahdeList.xlsx");
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No Records Found.....!');window.location ='ViewShadeListByStatus.aspx';", true);
            }
        }
    }
}