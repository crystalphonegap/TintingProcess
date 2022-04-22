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
    public partial class Export_All_Template : System.Web.UI.Page
    {
        private SqlCommand cmd, cmd2;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGFBasic();
            }
        }

        protected void grvFgBasic_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grvFgBasic_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindGFBasic();
            grvFgBasic.PageIndex = e.NewPageIndex;
            grvFgBasic.DataBind();
        }

        protected void GrvAltUom_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GrvAltUom_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindGFBasic();
            GrvAltUom.PageIndex = e.NewPageIndex;
            GrvAltUom.DataBind();
        }

        protected void GrvPlant_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GrvPlant_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindGFBasic();
            GrvPlant.PageIndex = e.NewPageIndex;
            GrvPlant.DataBind();
        }

        protected void GrvSplitVal_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GrvSplitVal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindGFBasic();
            GrvSplitVal.PageIndex = e.NewPageIndex;
            GrvSplitVal.DataBind();
        }

        protected void GrvMMSC_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GrvMMSC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindGFBasic();
            GrvMMSC.PageIndex = e.NewPageIndex;
            GrvMMSC.DataBind();
        }

        protected void BindGFBasic()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_EXP_DATA_PDL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ACTION", "FGBASIC");
                cmd.Parameters.AddWithValue("@P_FROMDATE", "");
                cmd.Parameters.AddWithValue("@P_TODATE", "");
                cmd.Parameters.AddWithValue("@P_KEYWORD", "");
                cmd.Parameters.AddWithValue("@P_TYPE", "All");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grvFgBasic.DataSource = ds.Tables[0];
                    grvFgBasic.DataBind();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    GrvAltUom.DataSource = ds.Tables[1];
                    GrvAltUom.DataBind();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    GrvPlant.DataSource = ds.Tables[2];
                    GrvPlant.DataBind();
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    GrvSplitVal.DataSource = ds.Tables[3];
                    GrvSplitVal.DataBind();
                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    GrvMMSC.DataSource = ds.Tables[4];
                    GrvMMSC.DataBind();
                }
                if (ds.Tables[5].Rows.Count > 0)
                {
                    grvSales.DataSource = ds.Tables[5];
                    grvSales.DataBind();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGFBasic();
        }

        protected void grvSales_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grvSales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindGFBasic();
            grvSales.PageIndex = e.NewPageIndex;
            grvSales.DataBind();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("PRC_EXP_DATA_PDL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_ACTION", "FGBASIC");
            cmd.Parameters.AddWithValue("@P_FROMDATE", "");
            cmd.Parameters.AddWithValue("@P_TODATE", "");
            cmd.Parameters.AddWithValue("@P_KEYWORD", "");
            cmd.Parameters.AddWithValue("@P_TYPE", "All");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grvFgBasic.DataSource = ds.Tables[0];
                grvFgBasic.DataBind();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                GrvAltUom.DataSource = ds.Tables[1];
                GrvAltUom.DataBind();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                GrvPlant.DataSource = ds.Tables[2];
                GrvPlant.DataBind();
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                GrvSplitVal.DataSource = ds.Tables[3];
                GrvSplitVal.DataBind();
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                GrvMMSC.DataSource = ds.Tables[4];
                GrvMMSC.DataBind();
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                grvSales.DataSource = ds.Tables[5];
                grvSales.DataBind();
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].TableName = "FG_EXP_BASIC";
                ds.Tables[1].TableName = "FG_EXP_ALT_UOM";
                ds.Tables[2].TableName = "FG_EXP_PALNT";
                ds.Tables[3].TableName = "FG_EXP_SPLIT_VAL";
                ds.Tables[4].TableName = "MMSC";
                ds.Tables[5].TableName = "FG_EXP_SALES";


                using (XLWorkbook wb = new XLWorkbook())
                {

                    foreach (DataTable dt in ds.Tables)
                    {
                        //Add DataTable as Worksheet.
                        wb.Worksheets.Add(dt);
                    }
                    // wb.Worksheets.Add(dt, "FGCLASS");
                    //var ws = wb.Worksheets.Add("FVCENVAT");
                    //ws.FirstRow().FirstCell().InsertData(ds.Tables[0].Rows);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Now.Date.ToString("dd/MM/yyyy") + "LSMW_Template.xlsx");
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No Records Found.....!');window.location ='Export_All_Template.aspx';", true);
            }
        }
    }
}