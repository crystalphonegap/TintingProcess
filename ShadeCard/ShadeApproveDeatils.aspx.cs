﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace ShadeCard
{
    public partial class ShadeApproveDeatils : System.Web.UI.Page
    {
        private SqlCommand cmd, cmd2;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    DivButton.Visible = false;
                    txtApproverRemarks.ReadOnly = true;
                    if (Session["UserType"].ToString() == "APPROVER")
                    {
                        DivButton.Visible = true;
                        txtApproverRemarks.ReadOnly = false;
                    }
                    lblShadeId.Text = Session["APPROVESHADEID"].ToString();
                    BindDetails();
                    //BindColorant();
                }
            }
            catch (Exception ex)
            {

            }
        }


        protected void BindDetails()
        {
            cmd = new SqlCommand("PRC_MS_GETSHADECARD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_ID", lblShadeId.Text);
            cmd.Parameters.AddWithValue("@P_PAGENO", 0);
            cmd.Parameters.AddWithValue("@P_PAGESIZE", 15);
            cmd.Parameters.AddWithValue("@P_ACTION", "SINGLE");
            cmd.Parameters.AddWithValue("@P_KEYWORD", "");
            cmd.Parameters.AddWithValue("@P_STATUS", "");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblDivision.Text = ds.Tables[0].Rows[0]["DivisionDescription"].ToString();
                lblSalesGroup.Text = ds.Tables[0].Rows[0]["SalesGroupDescription"].ToString();
                lblMaterialType.Text = ds.Tables[0].Rows[0]["MaterilaTypeDesc"].ToString();
                lblNMG.Text = ds.Tables[0].Rows[0]["NMG"].ToString();
                lblnmgCode.Text = ds.Tables[0].Rows[0]["NMG_CODE"].ToString();
                lblLevel4.Text = ds.Tables[0].Rows[0]["LEVEL4"].ToString();
                lblLevel4Code.Text = ds.Tables[0].Rows[0]["LEVEL4_CODE"].ToString();
                lblShadeName.Text = ds.Tables[0].Rows[0]["SHADE_NAME"].ToString();
                lblShadeCode.Text = ds.Tables[0].Rows[0]["SHADE_CODE_FTIN"].ToString();
                lblSubProductCode.Text = ds.Tables[0].Rows[0]["SUB_PRODUCT_CODE"].ToString();
                lblSubProductName.Text = ds.Tables[0].Rows[0]["SUB_PRODUCT_NAME"].ToString();
                lblShadeCode2.Text = ds.Tables[0].Rows[0]["SHADE_CODE"].ToString();
                txtDocNumber.Text = ds.Tables[0].Rows[0]["DOCUMENT_NUMBER"].ToString();
                txtDate.Text = ds.Tables[0].Rows[0]["DOCUMENT_DATES"].ToString();
                txtRemarks.Text = ds.Tables[0].Rows[0]["REMARK"].ToString();
                lblParentCode.Text = ds.Tables[0].Rows[0]["PARENT_CODE"].ToString();
                HColor1.Value = ds.Tables[0].Rows[0]["HEXADECIMAL"].ToString();
                txtParentDescription.Text = ds.Tables[0].Rows[0]["PARENT_DESCRIPTION"].ToString();
                txtReviewerRemarks.Text = ds.Tables[0].Rows[0]["REVIEWER_REMARKS"].ToString();
                txtApproverRemarks.Text = ds.Tables[0].Rows[0]["APPROVER_REMARKS"].ToString();

                string Status= ds.Tables[0].Rows[0]["STATUS"].ToString();

                if (Status == "P" || Status == "RV")
                {
                    btnSave.Visible = true;
                    btnReject.Visible = true;
                    btnSendback.Visible = true;
                }
                else
                {
                    btnSave.Visible = false;
                    btnReject.Visible = false;
                    btnSendback.Visible = false;
                }

                RptColorant.DataSource = ds.Tables[0];
                RptColorant.DataBind();
                DataTable dt = new DataTable();
                dt = BasicBindColorant();
                Control HeaderTemplate = RptColorant.Controls[0].Controls[0];
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    i++;
                    string ShortCode = dr["SHORT_CODE"].ToString();
                    string ColorCode = dr["HEXDECIMAL"].ToString();
                    (HeaderTemplate.FindControl("td" + i) as HtmlGenericControl).Attributes["Style"] = "padding:2px;background-color:" + ColorCode;
                    //(HeaderTemplate.FindControl("BColor" + i) as Label).BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCode);
                    (HeaderTemplate.FindControl("BColor" + i) as Label).Text = ShortCode;
                }
                RepSKU.DataSource = ds.Tables[1];
                RepSKU.DataBind();


            }
            else
            {

            }



        }

        protected void LinkView_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewApprovedShadeList.aspx");
        }

        protected void RptColorant_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {


        }

        protected void RepSKU_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                DataTable dt = BasicBindColorant();
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    i++;
                    (e.Item.FindControl("Label" + i) as Label).BackColor = System.Drawing.ColorTranslator.FromHtml(dr["HEXDECIMAL"].ToString());
                    (e.Item.FindControl("Label" + i) as Label).Text = dr["SHORT_CODE"].ToString();
                }

            }
        }



        protected DataTable BasicBindColorant()
        {
            DataTable dt = new DataTable();
            try
            {

                con.Open();
                cmd = new SqlCommand("PRC_MS_GETCOLORANTS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ID", 0);
                cmd.Parameters.AddWithValue("@P_PAGESIZE", 15);
                cmd.Parameters.AddWithValue("@P_PAGENO", 1);
                cmd.Parameters.AddWithValue("@P_ACTION", "All");
                cmd.Parameters.AddWithValue("@P_KEYWORD", "");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                RptColorantDetails.DataSource = dt;
                RptColorantDetails.DataBind();

            }
            catch (SqlException Ex)
            {

            }
            finally
            {
                con.Close();
            }

            return dt;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateDetails("A");
        }


        protected void UpdateDetails(string Status)
        {
            con.Open();
            try
            {

                cmd = new SqlCommand("PRC_MS_SHADE_ACTION_IUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_PARENT_CODE", lblParentCode.Text);
                cmd.Parameters.AddWithValue("@P_SHADE_CODE_FTIN", lblShadeCode.Text);
                cmd.Parameters.AddWithValue("@P_REMARKS", txtApproverRemarks.Text);
                cmd.Parameters.AddWithValue("@P_STATUS", Status);
                cmd.Parameters.AddWithValue("@TYPE", "APPROVER");
                cmd.Parameters.AddWithValue("@P_MAKE_BY", Session["Id"].ToString());
                cmd.Parameters.AddWithValue("@P_MAKES_BY_USERNAME", Session["UserName"].ToString()); ;
                cmd.Parameters.AddWithValue("@V_USERTYE", Session["UserType"].ToString());
                cmd.Parameters.AddWithValue("@P_ID", Session["APPROVESHADEID"].ToString());
                cmd.Parameters.AddWithValue("@P_SEESIONID", Session["Id"].ToString());
                cmd.Parameters.Add("@P_MESSAGES", SqlDbType.VarChar, 300);
                cmd.Parameters["@P_MESSAGES"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                string Messages = cmd.Parameters["@P_MESSAGES"].Value.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Messages + "');window.location ='ViewApprovedShadeList.aspx';", true);
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            UpdateDetails("R");
        }

        protected void btnSendback_Click(object sender, EventArgs e)
        {
            UpdateDetails("S");
        }

        protected void RptColorantDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                string ColorCode = (e.Item.FindControl("lblHexa1") as Label).Text;
                (e.Item.FindControl("lblHexa") as Label).BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCode);
                (e.Item.FindControl("lblHexa") as Label).ForeColor = System.Drawing.ColorTranslator.FromHtml(ColorCode);

            }
        }
    }
}