using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace ShadeCard
{
    public partial class UploadShadeName : System.Web.UI.Page
    {
        private SqlCommand cmd, cmd2;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        HttpPostedFileBase postedFile;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            ReadExcel();
        }


        public void ReadExcel()
        {
            if (fileupload.HasFile)
            {
                using (XLWorkbook workBook = new XLWorkbook(fileupload.PostedFile.InputStream))
                {
                    //Read the first Sheet from Excel file.
                    IXLWorksheet workSheet = workBook.Worksheet(1);

                    //Create a new DataTable.
                    DataTable dt = new DataTable();

                    //Loop through the Worksheet rows.
                    bool firstRow = true;
                    foreach (IXLRow row in workSheet.Rows())
                    {
                        //Use the first row to add columns to DataTable.
                        if (firstRow)
                        {
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            firstRow = false;
                        }
                        else
                        {
                            //Add rows to DataTable.
                            dt.Rows.Add();
                            int i = 0;
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                i++;
                            }
                        }


                    }
                    if (dt.Rows.Count > 0)
                    {
                        FillDetails(dt);
                        //btnCalculate_Click(this, EventArgs.Empty);
                    }
                }
            }
        }

        public void FillDetails(DataTable dt)
        {
            con.Open();
            string Messages = "";
            SqlTransaction sqltrans = con.BeginTransaction();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cmd = new SqlCommand("PRC_MS_SHADE_IUD", con, sqltrans);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_ID", lblId.Text);
                    cmd.Parameters.AddWithValue("@P_SUBPR_CODE", dr["SUB_PRODUCT_CODE"].ToString());
                    cmd.Parameters.AddWithValue("@P_SUBPR_DESC", dr["SUB_PRODUCT_NAME"].ToString());
                    cmd.Parameters.AddWithValue("@P_SHADE_NAME", dr["SHADE_NAME"].ToString());
                    cmd.Parameters.AddWithValue("@P_SHADE_CODE", dr["SHADE_CODE"].ToString());
                    cmd.Parameters.AddWithValue("@P_ADDED_BY", Session["Id"].ToString());
                    if (lblId.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@P_ACTION", "I");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@P_ACTION", "U");
                    }
                    cmd.Parameters.Add("@P_MESSAGE", SqlDbType.VarChar, 300);
                    cmd.Parameters["@P_MESSAGE"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    Messages = cmd.Parameters["@P_MESSAGE"].Value.ToString();

                }

                sqltrans.Commit();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Messages + "');window.location ='ViewShadeName.aspx';", true);
            }
            catch (SqlException ex)
            {
                sqltrans.Rollback();
            }
            finally
            {
                con.Close();
            }
        }


        protected void btnSampleFile_Click(object sender, EventArgs e)
        {
            string filePath = "~/uploads/UploadShadeNameFormat.xlsx";
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }
    }
}