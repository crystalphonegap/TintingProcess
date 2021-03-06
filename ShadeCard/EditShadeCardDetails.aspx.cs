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
    public partial class EditShadeCardDetails : System.Web.UI.Page
    {
        private SqlCommand cmd, cmd2;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lblSessionId.Text = Session["EDITSHADEHEADERID"].ToString();

                btnSubmit.Enabled = false;
                btnCancel.Enabled = false;
                btnDraft.Enabled = false;
                BindDivision();
                BindSubProduct();
                BindDetails();

            }
        }

        protected void BindDetails()
        {

            cmd = new SqlCommand("PRC_MS_GETSHADECARD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_ID", lblSessionId.Text);
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
                DropDivision.ClearSelection();
                DropDivision.Items.FindByText(ds.Tables[0].Rows[0]["DivisionDescription"].ToString()).Selected = true;
                DropDivision_SelectedIndexChanged(this, EventArgs.Empty);
                DropSalesGroup.ClearSelection();
                DropSalesGroup.Items.FindByText(ds.Tables[0].Rows[0]["SalesGroupDescription"].ToString()).Selected = true;
                DropSalesGroup_SelectedIndexChanged(this, EventArgs.Empty);
                DropMaterialType.ClearSelection();
                DropMaterialType.Items.FindByText(ds.Tables[0].Rows[0]["MaterilaTypeDesc"].ToString()).Selected = true;
                DropMaterialType_SelectedIndexChanged(this, EventArgs.Empty);
                DropLevel3.ClearSelection();
                DropLevel3.Items.FindByValue(ds.Tables[0].Rows[0]["NMG_CODE"].ToString()).Selected = true;
                DropLevel3_SelectedIndexChanged(this, EventArgs.Empty);
                lblnmgCode.Text = ds.Tables[0].Rows[0]["NMG_CODE"].ToString();
                DropLevel4.ClearSelection();
                DropLevel4.Items.FindByValue(ds.Tables[0].Rows[0]["LEVEL4_CODE"].ToString()).Selected = true;
                DropLevel4_SelectedIndexChanged(this, EventArgs.Empty);
                lblLevel4Code.Text = ds.Tables[0].Rows[0]["LEVEL4_CODE"].ToString();
                DropSubProdDesc.ClearSelection();
                DropSubProdDesc.Items.FindByValue(ds.Tables[0].Rows[0]["SUB_PRODUCT_CODE"].ToString()).Selected = true;
                txtSubProductCode.Text = ds.Tables[0].Rows[0]["SUB_PRODUCT_CODE"].ToString();
                DropSubProdDesc_SelectedIndexChanged(this, EventArgs.Empty);

                DropShadeName.ClearSelection();
                DropShadeName.Items.FindByText(ds.Tables[0].Rows[0]["SHADE_NAME"].ToString()).Selected = true;
                DropShadeCode.Items.FindByText(ds.Tables[0].Rows[0]["SHADE_CODE"].ToString()).Selected = true;

                //txtCodeShade.Text = ds.Tables[0].Rows[0]["SHADE_CODE"].ToString();
                txtShadeCode.Text = ds.Tables[0].Rows[0]["SHADE_CODE_FTIN"].ToString();

                txtDocNumber.Text = ds.Tables[0].Rows[0]["DOCUMENT_NUMBER"].ToString();
                txtDate.Text = ds.Tables[0].Rows[0]["DOCUMENT_DATES"].ToString();
                txtRemarks.Text = ds.Tables[0].Rows[0]["REMARK"].ToString();
                lblParentCode.Text = ds.Tables[0].Rows[0]["PARENT_CODE"].ToString();
                HColor1.Value = ds.Tables[0].Rows[0]["HEXADECIMAL"].ToString();
                HiddenR.Value = ds.Tables[0].Rows[0]["R_UNIT"].ToString();
                HiddenG.Value = ds.Tables[0].Rows[0]["G_UNIT"].ToString();
                HiddenB.Value = ds.Tables[0].Rows[0]["B_UNIT"].ToString();
                txtParentDescription.Text = ds.Tables[0].Rows[0]["PARENT_DESCRIPTION"].ToString();
                lblStatus.Text = ds.Tables[0].Rows[0]["STATUS"].ToString();

                if (lblStatus.Text == "P" || lblStatus.Text == "D")
                {

                    btnDraft.Visible = true;
                    btnSubmit.Visible = true;
                    btnDraft.Visible = true;
                }
                else
                {
                    btnDraft.Visible = false;
                    btnSubmit.Visible = false;
                    btnDraft.Visible = false;
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

                    (HeaderTemplate.FindControl("BColor" + i) as Label).Text = ShortCode;
                }


                btnCalculate_Click(this, EventArgs.Empty);
            }
            else
            {

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
        protected void DropSku_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblSKU.Text = DropSku.SelectedValue;
            //if (DropSku.SelectedItem.Text.Contains("9.5LT"))
            //{
            //    lblUOM.Text = "10";
            //}
            //else if (DropSku.SelectedItem.Text.Contains("19LT"))
            //{
            //    lblUOM.Text = "20";
            //}
            //else if (DropSku.SelectedItem.Text.Contains("3.8LT"))
            //{
            //    lblUOM.Text = "4";
            //}
            //else if (DropSku.SelectedItem.Text.Contains("950ML"))
            //{
            //    lblUOM.Text = "1";
            //}
            //else
            //{
            //    lblUOM.Text = "0";
            //}

        }
        protected void bindRPT()
        {
            cmd = new SqlCommand("PRC_MS_GENERATE_VARIENTCODE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_PRODUCTCODE", DropLevel4.SelectedValue);
            cmd.Parameters.AddWithValue("@P_NMGCODE", DropLevel3.SelectedValue);
            cmd.Parameters.AddWithValue("@P_LEVEL4CODE", DropLevel4.SelectedValue);
            cmd.Parameters.AddWithValue("@P_FLAG", "E");
            cmd.Parameters.AddWithValue("@P_ID", lblSessionId.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            RepSKU.DataSource = dt;
            RepSKU.DataBind();

            LoopingRpt();
        }
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            bindRPT();
            btnSubmit.Enabled = true;
            btnCancel.Enabled = true;
            btnDraft.Enabled = true;
        }
        protected void txtPackSize_TextChanged(object sender, EventArgs e)
        {
            LoopingRpt();
        }
        protected void LoopingRpt()
        {
            try
            {

                int i = 1;
                foreach (RepeaterItem itemcolorant in RptColorant.Items)
                {

                    Color1.Text = (itemcolorant.FindControl("txtColor1") as TextBox).Text;

                    Color2.Text = (itemcolorant.FindControl("txtColor2") as TextBox).Text;

                    Color3.Text = (itemcolorant.FindControl("txtColor3") as TextBox).Text;

                    Color4.Text = (itemcolorant.FindControl("txtColor4") as TextBox).Text;

                    Color5.Text = (itemcolorant.FindControl("txtColor5") as TextBox).Text;

                    Color6.Text = (itemcolorant.FindControl("txtColor6") as TextBox).Text;

                    Color7.Text = (itemcolorant.FindControl("txtColor7") as TextBox).Text;
                    Color8.Text = (itemcolorant.FindControl("txtColor8") as TextBox).Text;

                    Color9.Text = (itemcolorant.FindControl("txtColor9") as TextBox).Text;

                    Color10.Text = (itemcolorant.FindControl("txtColor10") as TextBox).Text;

                    Color11.Text = (itemcolorant.FindControl("txtColor11") as TextBox).Text;

                    Color12.Text = (itemcolorant.FindControl("txtColor12") as TextBox).Text;

                    Color13.Text = (itemcolorant.FindControl("txtColor13") as TextBox).Text;

                }

                int j = 0;
                decimal Rate = 0, WRate = 0, DRate = 0, PackSize = 0;
                foreach (RepeaterItem item in RepSKU.Items)
                {
                    j++;
                    TextBox txtPackSize = (item.FindControl("txtPackSize") as TextBox);
                    Control HeaderTemplate = RepSKU.Controls[0].Controls[0];
                    Label Rate1 = (HeaderTemplate.FindControl("Rate1") as Label);
                    Label WRate1 = (HeaderTemplate.FindControl("WRate1") as Label);
                    Label DRate1 = (HeaderTemplate.FindControl("DRate1") as Label);
                    Label Rate2 = (HeaderTemplate.FindControl("Rate2") as Label);
                    Label WRate2 = (HeaderTemplate.FindControl("WRate2") as Label);
                    Label DRate2 = (HeaderTemplate.FindControl("DRate2") as Label);
                    Label Rate3 = (HeaderTemplate.FindControl("Rate3") as Label);
                    Label WRate3 = (HeaderTemplate.FindControl("WRate3") as Label);
                    Label DRate3 = (HeaderTemplate.FindControl("DRate3") as Label);
                    Label Rate4 = (HeaderTemplate.FindControl("Rate4") as Label);
                    Label WRate4 = (HeaderTemplate.FindControl("WRate4") as Label);
                    Label DRate4 = (HeaderTemplate.FindControl("DRate4") as Label);
                    Label Rate5 = (HeaderTemplate.FindControl("Rate5") as Label);
                    Label WRate5 = (HeaderTemplate.FindControl("WRate5") as Label);
                    Label DRate5 = (HeaderTemplate.FindControl("DRate5") as Label);
                    Label Rate6 = (HeaderTemplate.FindControl("Rate6") as Label);
                    Label WRate6 = (HeaderTemplate.FindControl("WRate6") as Label);
                    Label DRate6 = (HeaderTemplate.FindControl("DRate6") as Label);
                    Label Rate7 = (HeaderTemplate.FindControl("Rate7") as Label);
                    Label WRate7 = (HeaderTemplate.FindControl("WRate7") as Label);
                    Label DRate7 = (HeaderTemplate.FindControl("DRate7") as Label);
                    Label Rate8 = (HeaderTemplate.FindControl("Rate8") as Label);
                    Label WRate8 = (HeaderTemplate.FindControl("WRate8") as Label);
                    Label DRate8 = (HeaderTemplate.FindControl("DRate8") as Label);
                    Label Rate9 = (HeaderTemplate.FindControl("Rate9") as Label);
                    Label WRate9 = (HeaderTemplate.FindControl("WRate9") as Label);
                    Label DRate9 = (HeaderTemplate.FindControl("DRate9") as Label);
                    Label Rate10 = (HeaderTemplate.FindControl("Rate10") as Label);
                    Label WRate10 = (HeaderTemplate.FindControl("WRate10") as Label);
                    Label DRate10 = (HeaderTemplate.FindControl("DRate10") as Label);
                    Label Rate11 = (HeaderTemplate.FindControl("Rate11") as Label);
                    Label WRate11 = (HeaderTemplate.FindControl("WRate11") as Label);
                    Label DRate11 = (HeaderTemplate.FindControl("DRate11") as Label);
                    Label Rate12 = (HeaderTemplate.FindControl("Rate12") as Label);
                    Label WRate12 = (HeaderTemplate.FindControl("WRate12") as Label);
                    Label DRate12 = (HeaderTemplate.FindControl("DRate12") as Label);
                    Label Rate13 = (HeaderTemplate.FindControl("Rate13") as Label);
                    Label WRate13 = (HeaderTemplate.FindControl("WRate13") as Label);
                    Label DRate13 = (HeaderTemplate.FindControl("DRate13") as Label);
                    //Label Rate14 = (HeaderTemplate.FindControl("Rate14") as Label);
                    //Label WRate14 = (HeaderTemplate.FindControl("WRate14") as Label);
                    //Label DRate14 = (HeaderTemplate.FindControl("DRate14") as Label);
                    //Label Rate15 = (HeaderTemplate.FindControl("Rate15") as Label);
                    //Label WRate15 = (HeaderTemplate.FindControl("WRate15") as Label);
                    //Label DRate15 = (HeaderTemplate.FindControl("DRate15") as Label);


                    //Label lblHeader = HeaderTemplate.FindControl("Rate1") as Label;


                    //string s = lblHeader.Text;
                    if (txtPackSize.Text == "")
                    {
                        txtPackSize.Text = "0";
                    }
                    else
                    {
                        PackSize = Convert.ToDecimal(txtPackSize.Text);
                    }



                    (item.FindControl("txtRColor1") as TextBox).Text = (Convert.ToDecimal(txtPackSize.Text.Trim()) * (Convert.ToDecimal(Color1.Text.Trim()))).ToString();
                    (item.FindControl("txtRColor2") as TextBox).Text = (Convert.ToDecimal(txtPackSize.Text.Trim()) * (Convert.ToDecimal(Color2.Text.Trim()))).ToString();
                    (item.FindControl("txtRColor3") as TextBox).Text = (Convert.ToDecimal(txtPackSize.Text.Trim()) * (Convert.ToDecimal(Color3.Text.Trim()))).ToString();
                    (item.FindControl("txtRColor4") as TextBox).Text = (Convert.ToDecimal(txtPackSize.Text.Trim()) * (Convert.ToDecimal(Color4.Text.Trim()))).ToString();
                    (item.FindControl("txtRColor5") as TextBox).Text = (Convert.ToDecimal(txtPackSize.Text.Trim()) * (Convert.ToDecimal(Color5.Text.Trim()))).ToString();
                    (item.FindControl("txtRColor6") as TextBox).Text = (Convert.ToDecimal(txtPackSize.Text.Trim()) * (Convert.ToDecimal(Color6.Text.Trim()))).ToString();
                    (item.FindControl("txtRColor7") as TextBox).Text = (Convert.ToDecimal(txtPackSize.Text.Trim()) * (Convert.ToDecimal(Color7.Text.Trim()))).ToString();
                    (item.FindControl("txtRColor8") as TextBox).Text = (Convert.ToDecimal(txtPackSize.Text.Trim()) * (Convert.ToDecimal(Color8.Text.Trim()))).ToString();
                    (item.FindControl("txtRColor9") as TextBox).Text = (Convert.ToDecimal(txtPackSize.Text.Trim()) * (Convert.ToDecimal(Color9.Text.Trim()))).ToString();
                    (item.FindControl("txtRColor10") as TextBox).Text = (Convert.ToDecimal(txtPackSize.Text.Trim()) * (Convert.ToDecimal(Color10.Text.Trim()))).ToString();
                    (item.FindControl("txtRColor11") as TextBox).Text = (Convert.ToDecimal(txtPackSize.Text.Trim()) * (Convert.ToDecimal(Color11.Text.Trim()))).ToString();
                    (item.FindControl("txtRColor12") as TextBox).Text = (Convert.ToDecimal(txtPackSize.Text.Trim()) * (Convert.ToDecimal(Color12.Text.Trim()))).ToString();
                    (item.FindControl("txtRColor13") as TextBox).Text = (Convert.ToDecimal(txtPackSize.Text.Trim()) * (Convert.ToDecimal(Color13.Text.Trim()))).ToString();
                    //(item.FindControl("txtRColor14") as TextBox).Text = (Convert.ToDecimal(txtPackSize.Text.Trim()) * (Convert.ToDecimal(Color14.Text.Trim()))).ToString();
                    //(item.FindControl("txtRColor15") as TextBox).Text = (Convert.ToDecimal(txtPackSize.Text.Trim()) * (Convert.ToDecimal(Color15.Text.Trim()))).ToString();

                    Rate = Convert.ToDecimal((item.FindControl("txtRColor1") as TextBox).Text) * Convert.ToDecimal(Rate1.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor2") as TextBox).Text) * Convert.ToDecimal(Rate2.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor3") as TextBox).Text) * Convert.ToDecimal(Rate3.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor4") as TextBox).Text) * Convert.ToDecimal(Rate4.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor5") as TextBox).Text) * Convert.ToDecimal(Rate5.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor6") as TextBox).Text) * Convert.ToDecimal(Rate6.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor7") as TextBox).Text) * Convert.ToDecimal(Rate7.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor8") as TextBox).Text) * Convert.ToDecimal(Rate8.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor9") as TextBox).Text) * Convert.ToDecimal(Rate9.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor10") as TextBox).Text) * Convert.ToDecimal(Rate10.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor11") as TextBox).Text) * Convert.ToDecimal(Rate11.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor12") as TextBox).Text) * Convert.ToDecimal(Rate12.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor13") as TextBox).Text) * Convert.ToDecimal(Rate13.Text.Trim());
                    //+ Convert.ToDecimal((item.FindControl("txtRColor14") as TextBox).Text) * Convert.ToDecimal(Rate14.Text.Trim()) +
                    //    Convert.ToDecimal((item.FindControl("txtRColor15") as TextBox).Text) * Convert.ToDecimal(Rate15.Text.Trim()));

                    WRate = Convert.ToDecimal((item.FindControl("txtRColor1") as TextBox).Text) * Convert.ToDecimal(WRate1.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor2") as TextBox).Text) * Convert.ToDecimal(WRate2.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor3") as TextBox).Text) * Convert.ToDecimal(WRate3.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor4") as TextBox).Text) * Convert.ToDecimal(WRate4.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor5") as TextBox).Text) * Convert.ToDecimal(WRate5.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor6") as TextBox).Text) * Convert.ToDecimal(WRate6.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor7") as TextBox).Text) * Convert.ToDecimal(WRate7.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor8") as TextBox).Text) * Convert.ToDecimal(WRate8.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor9") as TextBox).Text) * Convert.ToDecimal(WRate9.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor10") as TextBox).Text) * Convert.ToDecimal(WRate10.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor11") as TextBox).Text) * Convert.ToDecimal(WRate11.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor12") as TextBox).Text) * Convert.ToDecimal(WRate12.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor13") as TextBox).Text) * Convert.ToDecimal(WRate13.Text.Trim());
                    //+ Convert.ToDecimal((item.FindControl("txtRColor14") as TextBox).Text) * Convert.ToDecimal(WRate14.Text.Trim()) +
                    //    Convert.ToDecimal((item.FindControl("txtRColor15") as TextBox).Text) * Convert.ToDecimal(WRate15.Text.Trim());

                    DRate = Convert.ToDecimal((item.FindControl("txtRColor1") as TextBox).Text) * Convert.ToDecimal(DRate1.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor2") as TextBox).Text) * Convert.ToDecimal(DRate2.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor3") as TextBox).Text) * Convert.ToDecimal(DRate3.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor4") as TextBox).Text) * Convert.ToDecimal(DRate4.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor5") as TextBox).Text) * Convert.ToDecimal(DRate5.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor6") as TextBox).Text) * Convert.ToDecimal(DRate6.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor7") as TextBox).Text) * Convert.ToDecimal(DRate7.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor8") as TextBox).Text) * Convert.ToDecimal(DRate8.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor9") as TextBox).Text) * Convert.ToDecimal(DRate9.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor10") as TextBox).Text) * Convert.ToDecimal(DRate10.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor11") as TextBox).Text) * Convert.ToDecimal(DRate11.Text.Trim()) + Convert.ToDecimal((item.FindControl("txtRColor12") as TextBox).Text) * Convert.ToDecimal(DRate12.Text.Trim()) +
                        Convert.ToDecimal((item.FindControl("txtRColor13") as TextBox).Text) * Convert.ToDecimal(DRate13.Text.Trim());
                    //+ Convert.ToDecimal((item.FindControl("txtRColor14") as TextBox).Text) * Convert.ToDecimal(DRate14.Text.Trim()) +
                    //    Convert.ToDecimal((item.FindControl("txtRColor15") as TextBox).Text) * Convert.ToDecimal(DRate15.Text.Trim());

                    //(item.FindControl("txtRate1") as TextBox).Text = Rate.ToString(); 
                    //(item.FindControl("txtWRate") as TextBox).Text = WRate.ToString();
                    //(item.FindControl("txtDRate") as TextBox).Text = DRate.ToString();

                    (item.FindControl("txtRate1") as TextBox).Text = Math.Round(Rate, 2, MidpointRounding.AwayFromZero).ToString();
                    (item.FindControl("txtWRate") as TextBox).Text = Math.Round(WRate, 2, MidpointRounding.AwayFromZero).ToString();
                    (item.FindControl("txtDRate") as TextBox).Text = Math.Round(DRate, 2, MidpointRounding.AwayFromZero).ToString();


                }
                //string a=
                C1ltRate.Text = Math.Round((Rate / PackSize), 2, MidpointRounding.AwayFromZero).ToString();
                C1ltWSSRate.Text = Math.Round((WRate / PackSize), 2, MidpointRounding.AwayFromZero).ToString();
                C1ltDRate.Text = Math.Round((DRate / PackSize), 2, MidpointRounding.AwayFromZero).ToString();
            }
            catch (Exception ex)
            {

            }
        }
        protected void LinkView_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewShadeList.aspx");
        }

        protected void DropDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSalesGroup();
            BindMaterialType();
        }
        protected void DropSalesGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMaterialType();
        }
        protected void DropMaterialType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindNMG();
            BindLevel4();
        }
        protected void DropLevel3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropLevel4.Items.Clear();
            DropLevel4.ClearSelection();
            BindLevel4();
            lblnmgCode.Text = DropLevel3.SelectedValue;
            lblLevel4Code.Text = DropLevel4.SelectedValue;

        }
        protected void DropLevel4_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblLevel4Code.Text = DropLevel4.SelectedValue;
            BindMAXParentCode();


        }
        protected void BindMAXParentCode()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_MS_GETMAXDOCUMNET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_TYPE", "PARENTCODE");
                cmd.Parameters.AddWithValue("@P_NMGCODE", DropLevel3.SelectedValue);
                cmd.Parameters.AddWithValue("@P_LEVEL4CODE", DropLevel4.SelectedValue);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblParentCode.Text = dt.Rows[0]["PARENT_CODE"].ToString();
                }
                else
                {

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
        protected void BindDocumentNumber()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_MS_GETMAXDOCUMNET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_TYPE", "DOCUMENT");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtDocNumber.Text = dt.Rows[0]["MAXDOC"].ToString();
                }
                else
                {

                }
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
            BindSHADECODE();
        }
        protected void BindSHADECODE()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_MS_GETMAXDOCUMNET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_TYPE", "SHADE");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtShadeCode.Text = dt.Rows[0]["MAXSHADE"].ToString();
                }
                else
                {

                }
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
            BindMAXSHADECODE();
        }
        protected void BindMAXSHADECODE()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_MS_GETMAXDOCUMNET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_TYPE", "SHADECODE");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblOldShadeCode.Text = dt.Rows[0]["MAXSHADECODE"].ToString();
                }
                else
                {

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
        protected void BindDivision()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_MS_BINDDROPDOWN_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_TYPE", "DIVISION");
                cmd.Parameters.AddWithValue("@P_DIVISION", "");
                cmd.Parameters.AddWithValue("@P_GORUP", "");
                DropDivision.DataSource = cmd.ExecuteReader();
                DropDivision.DataTextField = "NAME";
                DropDivision.DataValueField = "CODE";
                DropDivision.DataBind();

                DropDivision.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
        protected void BindSalesGroup()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_MS_BINDDROPDOWN_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_TYPE", "GROUP");
                cmd.Parameters.AddWithValue("@P_DIVISION", DropDivision.SelectedValue);
                cmd.Parameters.AddWithValue("@P_GORUP", "");
                DropSalesGroup.DataSource = cmd.ExecuteReader();
                DropSalesGroup.DataTextField = "NAME";
                DropSalesGroup.DataValueField = "CODE";
                DropSalesGroup.DataBind();

                DropSalesGroup.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
        protected void BindMaterialType()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_MS_BINDDROPDOWN_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_TYPE", "MATERIAL");
                cmd.Parameters.AddWithValue("@P_DIVISION", DropDivision.SelectedValue);
                cmd.Parameters.AddWithValue("@P_GORUP", DropSalesGroup.SelectedValue);
                DropMaterialType.DataSource = cmd.ExecuteReader();
                DropMaterialType.DataTextField = "NAME";
                DropMaterialType.DataValueField = "CODE";
                DropMaterialType.DataBind();

                DropMaterialType.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
        protected void BindNMG()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_MS_BINDDROPDOWN_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_TYPE", "NMG");
                cmd.Parameters.AddWithValue("@P_DIVISION", DropDivision.SelectedValue);
                cmd.Parameters.AddWithValue("@P_GORUP", DropSalesGroup.SelectedValue);
                cmd.Parameters.AddWithValue("@P_MATERIALCODE", DropMaterialType.SelectedValue);
                DropLevel3.DataSource = cmd.ExecuteReader();
                DropLevel3.DataTextField = "NAME";
                DropLevel3.DataValueField = "CODE";
                DropLevel3.DataBind();

                DropLevel3.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
        protected void BindLevel4()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_MS_BINDDROPDOWN_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_TYPE", "LEVEL4");
                cmd.Parameters.AddWithValue("@P_DIVISION", DropDivision.SelectedValue);
                cmd.Parameters.AddWithValue("@P_GORUP", DropSalesGroup.SelectedValue);
                cmd.Parameters.AddWithValue("@P_MATERIALCODE", DropMaterialType.SelectedValue);
                cmd.Parameters.AddWithValue("@P_NMG", DropLevel3.SelectedValue);
                DropLevel4.DataSource = cmd.ExecuteReader();
                DropLevel4.DataTextField = "NAME";
                DropLevel4.DataValueField = "CODE";
                DropLevel4.DataBind();

                DropLevel4.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
        protected void BindColorant()
        {
            cmd = new SqlCommand("PRC_MS_GETCOLORANTS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_ACTION", "AllLIST");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                RptColorant.DataSource = dt;
                RptColorant.DataBind();
                RptColorantDetails.DataSource = dt;
                RptColorantDetails.DataBind();


            }

        }

        protected DataTable BindColorantDt()
        {
            cmd = new SqlCommand("PRC_MS_GETCOLORANTS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_ACTION", "AllLIST");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;

        }
        protected void RptColorant_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
        protected void RepSKU_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                DataTable dt = BindColorantDt();
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    i++;
                    (e.Item.FindControl("Label" + i) as Label).BackColor = System.Drawing.ColorTranslator.FromHtml(dr["HEXDECIMAL"].ToString());
                    (e.Item.FindControl("Label" + i) as Label).Text = dr["SHORT_CODE"].ToString();
                    (e.Item.FindControl("Rate" + i) as Label).Text = dr["RATE"].ToString();
                    (e.Item.FindControl("WRate" + i) as Label).Text = dr["WSSRATE"].ToString();
                    (e.Item.FindControl("DRate" + i) as Label).Text = dr["DEALERRATE"].ToString();
                }

            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (chkChecck.Checked == true)
            {
                InsertUpdated("P");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), " alert('Please Select Checkbox');", true);
                LoopingRpt();
            }


        }
        protected void InsertUpdated(string status)
        {

            con.Open();
            SqlTransaction sqltrans = con.BeginTransaction();
            try
            {


                cmd = new SqlCommand("PRC_MS_SHADECODE_IUD", con, sqltrans);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ID", lblSessionId.Text);
                cmd.Parameters.AddWithValue("@P_DIVISION", DropDivision.SelectedValue);
                cmd.Parameters.AddWithValue("@P_SALES_GROUP", DropSalesGroup.SelectedValue);
                cmd.Parameters.AddWithValue("@P_MATERIAL_TYPE", DropMaterialType.SelectedValue);
                //cmd.Parameters.AddWithValue("@P_SHADE_NAME", txtShade.Text);
                //cmd.Parameters.AddWithValue("@P_SHADE_CODE", txtCodeShade.Text);
                cmd.Parameters.AddWithValue("@P_SHADE_NAME", DropShadeName.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@P_SHADE_CODE", DropShadeCode.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@P_SHADE_CODE_FTIN", txtShadeCode.Text);

                cmd.Parameters.AddWithValue("@P_HEXADECIMAL", HColor1.Value);
                cmd.Parameters.AddWithValue("@P_R_UNIT", HiddenR.Value);
                cmd.Parameters.AddWithValue("@P_G_UNIT", HiddenG.Value);
                cmd.Parameters.AddWithValue("@P_B_UNIT", HiddenB.Value);
                cmd.Parameters.AddWithValue("@P_NMG", DropLevel3.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@P_NMG_CODE", DropLevel3.SelectedValue);
                cmd.Parameters.AddWithValue("@P_LEVEL4", DropLevel4.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@P_LEVEL4_CODE", DropLevel4.SelectedValue);
                cmd.Parameters.AddWithValue("@P_COLORANT1", Color1.Text.Trim());
                cmd.Parameters.AddWithValue("@P_COLORANT2", Color2.Text.Trim());
                cmd.Parameters.AddWithValue("@P_COLORANT3", Color3.Text.Trim());
                cmd.Parameters.AddWithValue("@P_COLORANT4", Color4.Text.Trim());
                cmd.Parameters.AddWithValue("@P_COLORANT5", Color5.Text.Trim());
                cmd.Parameters.AddWithValue("@P_COLORANT6", Color6.Text.Trim());
                cmd.Parameters.AddWithValue("@P_COLORANT7", Color7.Text.Trim());
                cmd.Parameters.AddWithValue("@P_COLORANT8", Color8.Text.Trim());
                cmd.Parameters.AddWithValue("@P_COLORANT9", Color9.Text.Trim());
                cmd.Parameters.AddWithValue("@P_COLORANT10", Color10.Text.Trim());
                cmd.Parameters.AddWithValue("@P_COLORANT11", Color11.Text.Trim());
                cmd.Parameters.AddWithValue("@P_COLORANT12", Color12.Text.Trim());
                cmd.Parameters.AddWithValue("@P_COLORANT13", Color13.Text.Trim());
                cmd.Parameters.AddWithValue("@P_COLORANT14", Color14.Text.Trim());
                cmd.Parameters.AddWithValue("@P_COLORANT15", Color15.Text.Trim());
                cmd.Parameters.AddWithValue("@P_RATE", C1ltRate.Text);
                cmd.Parameters.AddWithValue("@P_WSSRATE", C1ltWSSRate.Text);
                cmd.Parameters.AddWithValue("@P_DEALERRATE", C1ltDRate.Text);
                cmd.Parameters.AddWithValue("@P_PLANTCODE", "100");
                cmd.Parameters.AddWithValue("@P_COMPANY", 1);
                cmd.Parameters.AddWithValue("@P_REMARKS", txtRemarks.Text);
                cmd.Parameters.AddWithValue("@P_STATUS", status);
                cmd.Parameters.AddWithValue("@P_DOCUMNET_NUMBER", txtDocNumber.Text);
                cmd.Parameters.AddWithValue("@P_MAKE_BY", Session["Id"].ToString());
                cmd.Parameters.AddWithValue("@P_MAKES_BY_USERNAME", Session["UserName"].ToString());
                cmd.Parameters.AddWithValue("@P_HEADER_ID", 0);
                cmd.Parameters.AddWithValue("@P_SHADE_CRAD_CODE", 0);
                cmd.Parameters.AddWithValue("@P_PIL_SKU_CODE", 0);
                cmd.Parameters.AddWithValue("@P_ITEM_NAME", 0);
                cmd.Parameters.AddWithValue("@P_PACKSIZE", 0);
                cmd.Parameters.AddWithValue("@P_SKURATE", 0);
                cmd.Parameters.AddWithValue("@P_MEMO", 0);
                cmd.Parameters.AddWithValue("@P_NEWFILED", 0);
                cmd.Parameters.AddWithValue("@P_INSERT_TYPE", "H");
                cmd.Parameters.AddWithValue("@P_SUB_PRODUCT_NAME", DropSubProdDesc.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@P_SUB_PRODUCT_CODE", txtSubProductCode.Text);
                cmd.Parameters.AddWithValue("@P_ACTION", "U");
                cmd.Parameters.AddWithValue("@P_PARENT_CODE", lblParentCode.Text);
                cmd.Parameters.AddWithValue("@P_PARENT_DESCRIPTION", txtParentDescription.Text);
                cmd.Parameters.Add("@P_OUTPUTID", SqlDbType.Int, 300);
                cmd.Parameters["@P_OUTPUTID"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                string HeaderId = cmd.Parameters["@P_OUTPUTID"].Value.ToString();

                foreach (RepeaterItem item in RepSKU.Items)
                {
                    string[] s1 = (item.FindControl("txtRColor1") as TextBox).Text.Split(',');
                    string[] s2 = (item.FindControl("txtRColor2") as TextBox).Text.Split(',');
                    string[] s3 = (item.FindControl("txtRColor3") as TextBox).Text.Split(',');
                    string[] s4 = (item.FindControl("txtRColor4") as TextBox).Text.Split(',');
                    string[] s5 = (item.FindControl("txtRColor5") as TextBox).Text.Split(',');
                    string[] s6 = (item.FindControl("txtRColor6") as TextBox).Text.Split(',');
                    string[] s7 = (item.FindControl("txtRColor7") as TextBox).Text.Split(',');
                    string[] s8 = (item.FindControl("txtRColor8") as TextBox).Text.Split(',');
                    string[] s9 = (item.FindControl("txtRColor9") as TextBox).Text.Split(',');
                    string[] s10 = (item.FindControl("txtRColor10") as TextBox).Text.Split(',');
                    string[] s11 = (item.FindControl("txtRColor11") as TextBox).Text.Split(',');
                    string[] s12 = (item.FindControl("txtRColor12") as TextBox).Text.Split(',');
                    string[] s13 = (item.FindControl("txtRColor13") as TextBox).Text.Split(',');
                    //string[] s14 = (item.FindControl("txtRColor14") as TextBox).Text.Split(',');
                    //string[] s15 = (item.FindControl("txtRColor15") as TextBox).Text.Split(',');
                    string[] Rate = (item.FindControl("txtRate1") as TextBox).Text.Split(',');
                    string[] WRate = (item.FindControl("txtWRate") as TextBox).Text.Split(',');
                    string[] DRate = (item.FindControl("txtDRate") as TextBox).Text.Split(',');
                    cmd2 = new SqlCommand("PRC_MS_SHADECODE_IUD", con, sqltrans);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@P_COLORANT1", s1[0]);
                    cmd2.Parameters.AddWithValue("@P_COLORANT2", s2[0]);
                    cmd2.Parameters.AddWithValue("@P_COLORANT3", s3[0]);
                    cmd2.Parameters.AddWithValue("@P_COLORANT4", s4[0]);
                    cmd2.Parameters.AddWithValue("@P_COLORANT5", s5[0]);
                    cmd2.Parameters.AddWithValue("@P_COLORANT6", s6[0]);
                    cmd2.Parameters.AddWithValue("@P_COLORANT7", s7[0]);
                    cmd2.Parameters.AddWithValue("@P_COLORANT8", s8[0]);
                    cmd2.Parameters.AddWithValue("@P_COLORANT9", s9[0]);
                    cmd2.Parameters.AddWithValue("@P_COLORANT10", s10[0]);
                    cmd2.Parameters.AddWithValue("@P_COLORANT11", s11[0]);
                    cmd2.Parameters.AddWithValue("@P_COLORANT12", s12[0]);
                    cmd2.Parameters.AddWithValue("@P_COLORANT13", s13[0]);
                    cmd2.Parameters.AddWithValue("@P_COLORANT14", 0);
                    cmd2.Parameters.AddWithValue("@P_COLORANT15", 0);
                    cmd2.Parameters.AddWithValue("@P_RATE", Rate[0]);
                    cmd2.Parameters.AddWithValue("@P_WSSRATE", WRate[0]);
                    cmd2.Parameters.AddWithValue("@P_DEALERRATE", DRate[0]);
                    cmd2.Parameters.AddWithValue("@P_REMARKS", txtRemarks.Text);
                    cmd2.Parameters.AddWithValue("@P_HEADER_ID", HeaderId);
                    cmd2.Parameters.AddWithValue("@P_SHADE_CRAD_CODE", (item.FindControl("txtRnewSKu") as TextBox).Text);
                    cmd2.Parameters.AddWithValue("@P_PIL_SKU_CODE", (item.FindControl("lbrpSku") as Label).Text);
                    cmd2.Parameters.AddWithValue("@P_ITEM_NAME", (item.FindControl("lblItemName") as Label).Text);
                    cmd2.Parameters.AddWithValue("@P_PACKSIZE", (item.FindControl("txtPackSize") as TextBox).Text);
                    cmd2.Parameters.AddWithValue("@P_SKURATE", Rate[0]);
                    cmd2.Parameters.AddWithValue("@P_MEMO", 0);
                    cmd2.Parameters.AddWithValue("@P_NEWFILED", 0);
                    cmd2.Parameters.AddWithValue("@P_INSERT_TYPE", "D");
                    cmd2.Parameters.AddWithValue("@P_PARENT_CODE", lblParentCode.Text);
                    cmd2.Parameters.AddWithValue("@P_ACTION", "U");
                    cmd2.Parameters.Add("@P_OUTPUTID", SqlDbType.Int, 300);
                    cmd2.Parameters["@P_OUTPUTID"].Direction = ParameterDirection.Output;
                    cmd2.ExecuteNonQuery();

                }
                sqltrans.Commit();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Inserted Successfully...!');window.location ='AddShadeCard.aspx';", true);


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
        protected void btnDraft_Click(object sender, EventArgs e)
        {



            if (chkChecck.Checked == true)
            {
                InsertUpdated("D");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), " alert('Please Select Checkbox');", true);
                LoopingRpt();
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewShadeList.aspx");
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
        protected void BindShaderoduct()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_MS_BINDDROPDOWN_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_TYPE", "SUBSAHDE");
                cmd.Parameters.AddWithValue("@P_SUBPERCODE", DropSubProdDesc.SelectedValue);
                DropShadeName.DataSource = cmd.ExecuteReader();
                DropShadeName.DataTextField = "NAME";
                DropShadeName.DataValueField = "CODE";
                DropShadeName.DataBind();
                DropShadeName.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
        protected void BindShaderoductCode()
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("PRC_MS_BINDDROPDOWN_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_TYPE", "SUBSAHDECODE");
                cmd.Parameters.AddWithValue("@P_SUBPERCODE", DropSubProdDesc.SelectedValue);
                DropShadeCode.DataSource = cmd.ExecuteReader();
                DropShadeCode.DataTextField = "CODE";
                DropShadeCode.DataValueField = "NAME";
                DropShadeCode.DataBind();
                DropShadeCode.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
        protected void DropShadeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropShadeCode.ClearSelection();
            DropShadeCode.Items.FindByValue(DropShadeName.SelectedItem.Text).Selected = true;
        }
        protected void DropShadeCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropShadeName.ClearSelection();
            DropShadeName.Items.FindByValue(DropShadeCode.SelectedItem.Text).Selected = true;
        }

        protected void DropSubProdDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSubProductCode.Text = DropSubProdDesc.SelectedValue;
            BindShaderoduct();
            BindShaderoductCode();
        }
    }
}