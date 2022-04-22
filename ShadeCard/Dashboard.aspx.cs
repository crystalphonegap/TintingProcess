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
    public partial class Dashboard : System.Web.UI.Page
    {

        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strDBConnection"].ConnectionString);
        private SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DivAdmin.Visible = false;
                DivMaker.Visible = false;
                DivChecker.Visible = false;
                DivApprover.Visible = false;
                DivMDC.Visible = false;


                if (Session["UserType"].ToString() == "ADMIN")
                {
                    DivAdmin.Visible = true;
                 
                }
                else if (Session["UserType"].ToString() == "REVIEWER")
                {
                    DivChecker.Visible = true;
                  
                }
                else if (Session["UserType"].ToString() == "APPROVER")
                {
                    DivApprover.Visible = true;
                }
                else if (Session["UserType"].ToString() == "MAKER")
                {
                    DivMaker.Visible = true;
                }
                else if (Session["UserType"].ToString() == "MDC")
                {
                    DivMDC.Visible = true;
                }
                else
                {
                    DivAdmin.Visible = true;
                }


                if (!IsPostBack)
                {
                    Session["APSTATUS"] = null;
                    BindDashBoardCounts();
                    BindRepeater();
                    //bindGrid();
                }
            }
            catch (Exception)
            {

            }
        }

        protected void BindDashBoardCounts()
        {
            cmd = new SqlCommand("PRC_MS_GETDASHBOARD_DETAILS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_ACTION", "C");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblDraft.Text = dt.Rows[0]["DRAFT"].ToString();
                lblPending.Text = dt.Rows[0]["ALLPENDING"].ToString();
                lblRPending.Text= dt.Rows[0]["PENDING"].ToString();
                lblAPending.Text= dt.Rows[0]["PENDING"].ToString();
                

                lblSendBack.Text = dt.Rows[0]["SENDBACK"].ToString();
                lblMSendBAck.Text = dt.Rows[0]["SENDBACK"].ToString();
                lblASendBack.Text= dt.Rows[0]["SENDBACK"].ToString();
                lblRSendBack.Text= dt.Rows[0]["SENDBACK"].ToString();
                lblMDSendBack.Text= dt.Rows[0]["SENDBACK"].ToString();

                lblAccepted.Text = dt.Rows[0]["APPROVED"].ToString();
                lblMApprove.Text = dt.Rows[0]["APPROVED"].ToString();
                lblMDApprove.Text= dt.Rows[0]["APPROVED"].ToString();
                lblPendingWithMDC.Text= dt.Rows[0]["ACCEPTED"].ToString();
                lblMDPending.Text= dt.Rows[0]["ACCEPTED"].ToString();

                lblRejected.Text = dt.Rows[0]["REJECTED"].ToString();
                lblMRejected.Text = dt.Rows[0]["REJECTED"].ToString();
                lblARejected.Text = dt.Rows[0]["REJECTED"].ToString();
                lblMDReject.Text= dt.Rows[0]["REJECTED"].ToString();

                lblRReject.Text= dt.Rows[0]["REJECTED"].ToString();
                lblReview.Text = dt.Rows[0]["REVIEWED"].ToString();
                lblAReview.Text= dt.Rows[0]["REVIEWED"].ToString();
                lblPendingWithApprover.Text= dt.Rows[0]["REVIEWED"].ToString();


            }
        }

        protected void BindRepeater()
        {
            cmd = new SqlCommand("PRC_MS_GETDASHBOARD_DETAILS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_ACTION", "LEVEL3");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                RptNMG.DataSource = dt;
                RptNMG.DataBind();

            }
        }

        protected void RptNMG_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();
            if (e.CommandName == "View")
            {
                Session["NMGCODE"] = Id;
                Response.Redirect("ViewBaseProduct.aspx");
            }
            else
            {

            }
        }

        protected void btnAccepted1_Click(object sender, EventArgs e)
        {
            Session["APSTATUS"] = "M";
            Response.Redirect("ViewShadeListByStatus.aspx");
        }

        protected void btnSendBack1_Click(object sender, EventArgs e)
        {
            Session["APSTATUS"] = "S";
            Response.Redirect("ViewShadeListByStatus.aspx");
        }

        protected void btnReject1_Click(object sender, EventArgs e)
        {
            Session["APSTATUS"] = "R";
            Response.Redirect("ViewShadeListByStatus.aspx");
        }

        protected void btnPendingReviwer_Click(object sender, EventArgs e)
        {
            Session["APSTATUS"] = "ADMIN";
            Response.Redirect("ViewShadeListByStatus.aspx");
        }
        protected void btnPendingReviwer_Click2(object sender, EventArgs e)
        {
            Session["APSTATUS"] = "PR";
            Response.Redirect("ViewShadeListByStatus.aspx");
        }
        protected void btnPendingApprover_Click(object sender, EventArgs e)
        {
            Session["APSTATUS"] = "PA";
            Response.Redirect("ViewShadeListByStatus.aspx");
        }

        protected void btnPedningithMDD_Click(object sender, EventArgs e)
        {
            Session["APSTATUS"] = "PM";
            Response.Redirect("ViewShadeListByStatus.aspx");
        }

        protected void btnDraftLink_Click(object sender, EventArgs e)
        {
            Session["APSTATUS"] = "D";
            Response.Redirect("ViewShadeList.aspx");
        }

        protected void btnMakerRejected_Click(object sender, EventArgs e)
        {
            Session["APSTATUS"] = "R";
            Response.Redirect("ViewShadeList.aspx");
        }

        protected void btnMsendBack_Click(object sender, EventArgs e)
        {
            Session["APSTATUS"] = "S";
            Response.Redirect("ViewShadeList.aspx");
        }

        protected void btnMApprove_Click(object sender, EventArgs e)
        {
            Session["APSTATUS"] = "M";
            Response.Redirect("ViewShadeList.aspx");
        }

        protected void btnMdc_Click(object sender, EventArgs e)
        {
            Session["APSTATUS"] = "PM";
            Response.Redirect("ShadeListForMDC.aspx");
        }

        protected void btnMDCApprove_Click(object sender, EventArgs e)
        {
            Session["APSTATUS"] = "M";
            Response.Redirect("ShadeListForMDC.aspx");
        }
    }
}