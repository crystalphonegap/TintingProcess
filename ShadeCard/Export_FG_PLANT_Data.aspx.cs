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
    public partial class Export_FG_PLANT_Data : System.Web.UI.Page
    {
        private SqlCommand cmd, cmd2;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ExportFGClass();
            }
        }

        protected void GrvData_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GrvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ExportFGClass();
            GrvData.PageIndex = e.NewPageIndex;
            GrvData.DataBind();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("PRC_EXP_DATA_PDL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_ACTION", "FGPLANT");
            cmd.Parameters.AddWithValue("@P_FROMDATE", "");
            cmd.Parameters.AddWithValue("@P_TODATE", "");
            cmd.Parameters.AddWithValue("@P_KEYWORD", "");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                using (XLWorkbook wb = new XLWorkbook())
                {
                    // wb.Worksheets.Add(dt, "FGCLASS");
                    var ws = wb.Worksheets.Add("FVCENVAT");
                    ws.FirstRow().FirstCell().InsertData(dt.Rows);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Now.Date.ToString("dd/MM/yyyy") + "Export_MMSC_Sheet.xlsx");
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No Records Found.....!');window.location ='Export_MMSC_Sheet.aspx';", true);
            }
        }

        protected void ExportFGClass()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_EXP_DATA_PDL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ACTION", "FGPLANT");
                cmd.Parameters.AddWithValue("@P_FROMDATE", "");
                cmd.Parameters.AddWithValue("@P_TODATE", "");
                cmd.Parameters.AddWithValue("@P_KEYWORD", "");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GrvData.DataSource = dt;
                    GrvData.DataBind();
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
    }
}