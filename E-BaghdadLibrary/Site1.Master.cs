using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrary
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToLongTimeString();
            
                if (Session["role"] == null)
                {
                    LinkButtonUserLogin.Visible = true;
                    LinkButtonSignUp.Visible = true;

                    LinkButtonLogout.Visible = false;
                    LinkButtonHelloUser.Visible = false;

                    LinkButtonAdminLogin.Visible = true;
                    LinkButtonAuthorManagement.Visible = false;
                    LinkButtonPublisherManagement.Visible = false;
                    LinkButtonBookInventory.Visible = false;
                    LinkButtonBookIssuing.Visible = false;
                    LinkButtonMemberManagement.Visible = false;
                }
                else if (Session["role"].Equals("user"))
                {

                    LinkButtonUserLogin.Visible = false;
                    LinkButtonSignUp.Visible = false;

                    LinkButtonLogout.Visible = true;
                    LinkButtonHelloUser.Visible = true;
                    LinkButtonHelloUser.Text ="Hello, "+ Session["MemberID"].ToString() ;

                    LinkButtonAdminLogin.Visible = true;
                    LinkButtonAuthorManagement.Visible = false;
                    LinkButtonPublisherManagement.Visible = false;
                    LinkButtonBookInventory.Visible = false;
                    LinkButtonBookIssuing.Visible = false;
                    LinkButtonMemberManagement.Visible = false;
                }
                else if (Session["role"].Equals("admin"))
                {

                    LinkButtonUserLogin.Visible = false;
                    LinkButtonSignUp.Visible = false;

                    LinkButtonLogout.Visible = true;
                    LinkButtonHelloUser.Visible = true;
                    LinkButtonHelloUser.Text = "Hello, Admin ";

                    LinkButtonAdminLogin.Visible = false;
                    LinkButtonAuthorManagement.Visible = true;
                    LinkButtonPublisherManagement.Visible = true;
                    LinkButtonBookInventory.Visible = true;
                    LinkButtonBookIssuing.Visible = true;
                    LinkButtonMemberManagement.Visible = true;
                }
            
              
            
            
        }

        
        protected void LinkButtonAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LinkButtonAuthorManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAuthorManagement.aspx");
        }

        protected void LinkButtonPublisherManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminPublisherManagment.aspx");
        }

        protected void LinkButtonBookInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminBookInventory.aspx");
        }

        protected void LinkButtonBookIssuing_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminBookIssuing.aspx");
        }

        protected void LinkButtonMemberManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminMemberManagment.aspx");
        }

        protected void LinkButtonViewBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewBooks.aspx");
        }

        protected void LinkButtonUserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void LinkButtonSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("userSignUp.aspx");
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session["MemberID"] = null;
            Session["fullname"] = null;
            Session["role"] = null;
            Session["status"] = null;
            Response.Redirect("HomePage.aspx");
        }

        protected void LinkButtonHelloUser_Click(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "user")
            Response.Redirect("userProfile.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToLongTimeString();
        }
    }
}