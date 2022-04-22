using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace ShadeCard
{
    public partial class AddColorants : System.Web.UI.Page
    {
        private SqlCommand cmd;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    
                    lblId.Text = Session["ColorantId"].ToString();
                    string Status = Session["ViewStatus"].ToString();
                    if(Status== "View")
                    {
                        txtColorName.ReadOnly = true;
                        txtDealerRate.ReadOnly = true;
                        txtRate.ReadOnly = true;
                        txtRemarks.ReadOnly = true;
                        txtShortCode.ReadOnly = true;
                        txtSKU.ReadOnly = true;
                        txtWssRate.ReadOnly = true;
                        btnAdd.Visible = false;
                    }
                    BindDetails(lblId.Text);
                }
            }
            catch (Exception)
            {
               // Response.Redirect("ViewColorants.aspx");
            }
        }
        protected void BindDetails(string ColorantId)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand("PRC_MS_GETCOLORANTS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ID", Convert.ToInt32(ColorantId));
                cmd.Parameters.AddWithValue("@P_PAGESIZE", 10);
                cmd.Parameters.AddWithValue("@P_PAGENO", 1);
                cmd.Parameters.AddWithValue("@P_ACTION", "SINGLE");
                cmd.Parameters.AddWithValue("@P_KEYWORD", "");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    txtSKU.Text = dt.Rows[0]["PILSKU_CODE"].ToString();
                    txtColorName.Text = dt.Rows[0]["COLOR_NAME"].ToString();
                    txtShortCode.Text = dt.Rows[0]["SHORT_CODE"].ToString();
                    txtRate.Text = dt.Rows[0]["RATE"].ToString();
                    txtWssRate.Text = dt.Rows[0]["WSSRATE"].ToString();
                    txtDealerRate.Text = dt.Rows[0]["DEALERRATE"].ToString();
                    lblHexaCode.Text = dt.Rows[0]["HEXDECIMAL"].ToString();
                    txtRemarks.Text = dt.Rows[0]["REMARKS"].ToString();
                    lblcolorcode.Text = dt.Rows[0]["HEXDECIMAL"].ToString();
                    txtFromDate.Text= dt.Rows[0]["STRAT_DATE"].ToString();
                    txtToDate.Text = dt.Rows[0]["END_DATE"].ToString();
                    HiddenR.Value = dt.Rows[0]["R_UNIT"].ToString();
                    HiddenG.Value = dt.Rows[0]["G_UNIT"].ToString();
                    HiddenB.Value = dt.Rows[0]["B_UNIT"].ToString();

                }
            }
            catch (SqlException Ex)
            {

            }
            finally
            {
                con.Close();
            }
            color1.Value = lblHexaCode.Text;


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Session["ColorantId"] = null;
            Session["ViewStatus"] = null;
            Response.Redirect("ViewColorants.aspx");


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_MS_COLORANT_IUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ID", lblId.Text);
                cmd.Parameters.AddWithValue("@P_SKUCODE", txtSKU.Text);
                cmd.Parameters.AddWithValue("@P_COLORNAME", txtColorName.Text);
                cmd.Parameters.AddWithValue("@P_SHORTCODE", txtShortCode.Text);
                cmd.Parameters.AddWithValue("@P_RATE", Convert.ToDecimal(txtRate.Text));
                cmd.Parameters.AddWithValue("@P_WSSRATE", Convert.ToDecimal(txtWssRate.Text));
                cmd.Parameters.AddWithValue("@P_DEALERRATE", Convert.ToDecimal(txtDealerRate.Text));
                cmd.Parameters.AddWithValue("@P_ADDEDBY", Session["Id"].ToString());
                cmd.Parameters.AddWithValue("@P_UPDATEDBY", Session["Id"].ToString());
                if (lblId.Text == "")
                {
                    cmd.Parameters.AddWithValue("@P_ACTION", "I");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@P_ACTION", "U");
                }

                cmd.Parameters.AddWithValue("@P_HEXDECIMAL", color1.Value);
                cmd.Parameters.AddWithValue("@P_STARTDATE", Convert.ToDateTime(txtFromDate.Text));
                cmd.Parameters.AddWithValue("@P_ENDDATE", Convert.ToDateTime(txtToDate.Text));
                cmd.Parameters.AddWithValue("@P_R", HiddenR.Value);
                cmd.Parameters.AddWithValue("@P_G", HiddenG.Value);
                cmd.Parameters.AddWithValue("@P_B", HiddenB.Value);
                cmd.Parameters.Add("@P_MESSAGE", SqlDbType.VarChar, 300);
                cmd.Parameters["@P_MESSAGE"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@P_REMARKS", txtRemarks.Text);
                cmd.ExecuteNonQuery();

                string Messages = cmd.Parameters["@P_MESSAGE"].Value.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('"+Messages+ "');window.location ='ViewColorants.aspx';", true);


            }
            catch (SqlException Ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
    }
}