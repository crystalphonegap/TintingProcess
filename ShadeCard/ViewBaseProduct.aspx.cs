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
    public partial class ViewBaseProduct : System.Web.UI.Page
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        private SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lblNMGCode.Text = Session["NMGCODE"].ToString();
                    BindRepeater();
                }
            }
            catch (Exception)
            {

            }
        }

        protected void BindRepeater()
        {
            cmd = new SqlCommand("PRC_MS_GETDASHBOARD_DETAILS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_ACTION", "LEVEL4");
            cmd.Parameters.AddWithValue("@P_NMGCODE", lblNMGCode.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                RptBase.DataSource = dt;
                RptBase.DataBind();

            }
        }

        protected void RptBase_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();
            if (e.CommandName == "View")
            {
                Session["BaseCODE"] = Id;
                Session["Product"] = "M";
                //Response.Redirect("ViewApprovedShadeList.aspx");
                Response.Redirect("ShadeListByBase.aspx");
                
            }
            else
            {

            }
        }

        protected void LinkView_Click(object sender, EventArgs e)
        {
            Session["NMGCODE"] = null;
            Response.Redirect("Dashboard.aspx");
        }
    }
}