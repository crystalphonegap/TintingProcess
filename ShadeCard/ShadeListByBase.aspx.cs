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

namespace ShadeCard
{
    public partial class ShadeListByBase : System.Web.UI.Page
    {
        private SqlCommand cmd, cmd2;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                  
                    lblBaseId.Text= Session["BaseCODE"].ToString();
                }
                catch (Exception)
                {

                }

                bindGrid(1, 15);
            }
        }

        protected void bindGrid(int PageNumber, int PageSize)
        {
            cmd = new SqlCommand("PRC_MS_GETSHADELISTBY_BASE", con);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.AddWithValue("@P_CODE", lblBaseId.Text);
            cmd.Parameters.AddWithValue("@P_KEYWORD", 0);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gvShadeCard.DataSource = dt;
                gvShadeCard.DataBind();

                //PopulatePager(Convert.ToInt32(dt.Rows[0]["Total"].ToString()), PageNumber);
                // lblCounts.Text = " Total Records :" + dt.Rows[0]["Total"].ToString();


            }
            else
            {
                gvShadeCard.DataSource = null;
                gvShadeCard.DataBind();

                //PopulatePager(0, 1);
            }


        }

        //private void PopulatePager(int recordCount, int currentPage)
        //{
        //    string pagesize = "15";
        //    double dblPageCount = (double)((decimal)recordCount / decimal.Parse(pagesize));
        //    int pageCount = (int)Math.Ceiling(dblPageCount);
        //    List<ListItem> pages = new List<ListItem>();
        //    if (pageCount > 0)
        //    {
        //        pages.Add(new ListItem("First", "1", currentPage > 1));
        //        for (int i = 1; i <= pageCount; i++)
        //        {
        //            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
        //        }
        //        pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
        //    }
        //    rptPager.DataSource = pages;
        //    rptPager.DataBind();
        //}

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
                Session["APPROVESHADEID"] = Id;
                Response.Redirect("ShadeApproveDeatils.aspx");
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindGrid(1,5);
        }

        protected void gvShadeCard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShadeCard.PageIndex = e.NewPageIndex;
            this.bindGrid(1,5);
        }

        protected void gvShadeCard_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}