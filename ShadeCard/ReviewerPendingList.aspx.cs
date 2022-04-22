using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Text;
using ClosedXML.Excel;
using System.IO;

namespace ShadeCard
{
    public partial class ReviewerPendingList : System.Web.UI.Page
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
            cmd = new SqlCommand("PRC_MS_GETSHADECARD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_ID", 0);
            cmd.Parameters.AddWithValue("@P_PAGENO", PageNumber);
            cmd.Parameters.AddWithValue("@P_PAGESIZE", PageSize);
            cmd.Parameters.AddWithValue("@P_ACTION", "All");
            cmd.Parameters.AddWithValue("@P_KEYWORD", txtShadeCode.Text);
            cmd.Parameters.AddWithValue("@P_STATUS", DropStatus.SelectedValue);
            cmd.Parameters.AddWithValue("@P_FROMDATE", Convert.ToDateTime(txtFromDate.Text));
            cmd.Parameters.AddWithValue("@P_TODATE", Convert.ToDateTime(txtToDate.Text));
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gvShadeCard.DataSource = dt;
                gvShadeCard.DataBind();

                PopulatePager(Convert.ToInt32(dt.Rows[0]["Total"].ToString()), PageNumber);
                // lblCounts.Text = " Total Records :" + dt.Rows[0]["Total"].ToString();


            }
            else
            {
                gvShadeCard.DataSource = null;
                gvShadeCard.DataBind();

                PopulatePager(0, 1);
            }


        }

        private void PopulatePager(int recordCount, int currentPage)
        {
            string pagesize = "15";
            double dblPageCount = (double)((decimal)recordCount / decimal.Parse(pagesize));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            List<ListItem> pages = new List<ListItem>();
            if (pageCount > 0)
            {
                pages.Add(new ListItem("First", "1", currentPage > 1));
                for (int i = 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
                pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
            }
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.bindGrid(pageIndex, 15);
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
            string Id = e.CommandArgument.ToString();
            if (e.CommandName == "View")
            {
                Session["SHADEHEADERID"] = Id;
                Response.Redirect("ViewShadeCardDetails.aspx");
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

        protected void btnExport_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("PRC_EXPORT_DATA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_KEYWORD", txtShadeCode.Text);
            cmd.Parameters.AddWithValue("@P_STATUS", DropStatus.SelectedValue);
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No Records Found.....!');window.location ='ReviewerPendingList.aspx';", true);
            }
        }
    }
}