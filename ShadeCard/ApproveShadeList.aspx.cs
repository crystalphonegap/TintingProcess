using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ClosedXML.Excel;

namespace ShadeCard
{
    public partial class ApproveShadeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }
        protected void bindGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8] { new DataColumn("SR", typeof(int)),
                     new DataColumn("DOCNo", typeof(string)),
                         new DataColumn("DocDate", typeof(string)),
                        new DataColumn("ShadeName", typeof(string)),
                         new DataColumn("ShadeCode", typeof(string)),
                          new DataColumn("NMG", typeof(string)),
                          new DataColumn("Level4", typeof(string)),
                               new DataColumn("Status", typeof(string)),

                         });
            dt.Rows.Add(1, "D0001", "02/03/2022", "Happy Green", "100001", "DR. FIXIT RAINCOAT", "WHITE BASE", "Approve");
            dt.Rows.Add(2, "D0002", "01/03/2022", "Happy Red", "100002", "DR. FIXIT RAINCOAT", "WHITE BASE", "Approve");
            dt.Rows.Add(3, "D0003", "28/02/2022", "Happy Blue", "100003", "DR. FIXIT RAINCOAT", "MID TONE BASE", "Approve");
            dt.Rows.Add(4, "D0004", "28/02/2022", "Happy Gray", "100004", "DR. FIXIT RAINCOAT", "MID TONE BASE", "Approve");
            dt.Rows.Add(5, "D0005", "27/02/2022", "Happy Orange", "100005", "DR. FIXIT RAINCOAT", "RAINCOAT SHADES", "Approve");
            dt.Rows.Add(6, "D0006", "26/02/2022", "Happy YellowGreen", "100006", "DR. FIXIT RAINCOAT", "DARK TONE BASE", "Approve");

            //DataColumn dataColumn = new DataColumn("Occasion", typeof(string));
            //dataColumn.DefaultValue = "Test";
            //dt.Columns.Add(dataColumn);


            gvShadeCard.DataSource = dt;
            gvShadeCard.DataBind();
        }

        protected void LinkView_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8] { new DataColumn("SR", typeof(int)),
                     new DataColumn("DOCNo", typeof(string)),
                         new DataColumn("DocDate", typeof(string)),
                        new DataColumn("ShadeName", typeof(string)),
                         new DataColumn("ShadeCode", typeof(string)),
                          new DataColumn("NMG", typeof(string)),
                          new DataColumn("Level4", typeof(string)),
                               new DataColumn("Status", typeof(string)),

                         });
            dt.Rows.Add(1, "D0001", "02/03/2022", "Happy Green", "100001", "DR. FIXIT RAINCOAT", "WHITE BASE", "Approve");
            dt.Rows.Add(2, "D0002", "01/03/2022", "Happy Red", "100002", "DR. FIXIT RAINCOAT", "WHITE BASE", "Approve");
            dt.Rows.Add(3, "D0003", "28/02/2022", "Happy Blue", "100003", "DR. FIXIT RAINCOAT", "MID TONE BASE", "Approve");
            dt.Rows.Add(4, "D0004", "28/02/2022", "Happy Gray", "100004", "DR. FIXIT RAINCOAT", "MID TONE BASE", "Approve");
            dt.Rows.Add(5, "D0005", "27/02/2022", "Happy Orange", "100005", "DR. FIXIT RAINCOAT", "RAINCOAT SHADES", "Approve");
            dt.Rows.Add(6, "D0006", "26/02/2022", "Happy YellowGreen", "100006", "DR. FIXIT RAINCOAT", "DARK TONE BASE", "Approve");
           
           
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Customers");

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }

        }



    }
}