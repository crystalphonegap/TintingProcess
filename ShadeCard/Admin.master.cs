using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShadeCard
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                lblMasterUserName.Text = Session["UserName"].ToString();
                lblMasterUserCode.Text = Session["UserCode"].ToString();
                lblMasterUserType.Text = Session["UserType"].ToString();
                lblMasterUserEmail.Text = Session["UserEmail"].ToString();
                lblMasterUserId.Text = Session["Id"].ToString();
                PageAccess(lblMasterUserType.Text);

            }
            catch (Exception)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void PageAccess(string Types)
        {
            AddShade.Visible = false;
            ShadeListForMDC.Visible = false;
            ShadeList.Visible = false;
            Colorants.Visible = false;
            Employees.Visible = false;
            ApShadeList.Visible = false;
            ReShadeList.Visible = false;
            ShadeName.Visible = false;
            Upload.Visible = false;
            Rpt2.Visible = false;
            Rpt3.Visible = false;
            Rpt4.Visible = false;
            Rpt5.Visible = false;
            Rpt6.Visible = false;
            UploadShadeName.Visible = false;
            LSMW.Visible = false;


            if (Types == "ADMIN")
            {
                Dashboard.Visible = true;
                ShadeList.Visible = true;
                Colorants.Visible = true;
                Employees.Visible = true;
                ShadeName.Visible = true;
                Upload.Visible = true;
                UploadShadeName.Visible = true;
                LSMW.Visible = true;

            }
            else if (Types == "REVIEWER")
            {
                Dashboard.Visible = true;
                ReShadeList.Visible = true;
            }
            else if (Types == "APPROVER")
            {
                Dashboard.Visible = true;
                ApShadeList.Visible = true;
                ReShadeList.Visible = false;
            }
            else if (Types == "MAKER")
            {
                Dashboard.Visible = true;
                ShadeList.Visible = true;
                AddShade.Visible = true;
                ShadeName.Visible = true;
                Upload.Visible = true;
                UploadShadeName.Visible = true;
                
            }
            else if (Types == "MDC")
            {
                Dashboard.Visible = true;
                ShadeListForMDC.Visible = true;
               
                LSMW.Visible = true;
                //Rpt2.Visible = true;
                //Rpt3.Visible = true;
                //Rpt4.Visible = true;
                //Rpt5.Visible = true;
                //Rpt6.Visible = true;

            }
            else
            {
                ApShadeList.Visible = false;
                ReShadeList.Visible = false;
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}