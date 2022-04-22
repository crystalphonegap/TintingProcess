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
    public partial class AddShadeName : System.Web.UI.Page
    {
        private SqlCommand cmd;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindSubProduct();
                    lblId.Text = Session["SHADENAMEID"].ToString();
                    string Status = Session["SHADENAMEVIEW"].ToString();
                    if (Status == "View")
                    {
                     
                        btnAdd.Visible = false;
                    }
                    BindDetails(lblId.Text);
                   
                }
            }
            catch (Exception ex)
            {
                // Response.Redirect("ViewColorants.aspx");
            }
        }
        protected void BindDetails(string ColorantId)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand("PRC_MS_GETSHDAENAME_LIST", con);
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
                    DropSubProdDesc.Items.FindByValue(dt.Rows[0]["SUBPR_CODE"].ToString()).Selected = true;
                    txtSubProductCode.Text = dt.Rows[0]["SUBPR_CODE"].ToString();
                    txtShade.Text = dt.Rows[0]["SHADE_NAME"].ToString();
                    txtShadeCode.Text = dt.Rows[0]["SHADE_CODE"].ToString();

                }
            }
            catch (SqlException Ex)
            {

            }
            finally
            {
                con.Close();
            }



        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Session["SHADENAMEID"] = null;
            Session["SHADENAMEVIEW"] = null;
            Response.Redirect("ViewShadeName.aspx");


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_MS_SHADE_IUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ID", lblId.Text);
                cmd.Parameters.AddWithValue("@P_SUBPR_CODE", DropSubProdDesc.SelectedValue);
                cmd.Parameters.AddWithValue("@P_SUBPR_DESC", DropSubProdDesc.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@P_SHADE_NAME", txtShade.Text);
                cmd.Parameters.AddWithValue("@P_SHADE_CODE", txtShadeCode.Text);
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

                string Messages = cmd.Parameters["@P_MESSAGE"].Value.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Messages + "');window.location ='ViewShadeName.aspx';", true);


            }
            catch (SqlException Ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        protected void BindSubProduct()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_MS_BINDDROPDOWN_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_TYPE", "SUPERCODE");
                DropSubProdDesc.DataSource = cmd.ExecuteReader();
                DropSubProdDesc.DataTextField = "NAME";
                DropSubProdDesc.DataValueField = "CODE";
                DropSubProdDesc.DataBind();
                DropSubProdDesc.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        protected void DropSubProdDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSubProductCode.Text = DropSubProdDesc.SelectedValue;
        }
    }
}