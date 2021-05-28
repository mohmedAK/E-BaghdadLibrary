using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELibrary.Model;
using ELibrary.Controller;
namespace ELibrary
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        CMD_AdminLogin CMD_Admin = new CMD_AdminLogin();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxUsername.Text) || string.IsNullOrWhiteSpace(TextBoxPassword.Text))
            {
                Response.Write("<script>alert('Please Fill Username or Password Field'); </script>");
                return;
            }
            login();
        }

        void login()
        {
            List<CLS_AdminLogin> Admins = CMD_Admin.GetAllAdmins().Where(c => c.username == TextBoxUsername.Text.Trim() && c.password == TextBoxPassword.Text.Trim()).ToList();
            if (Admins.Count >= 1)
            {
                Admins.ForEach(c =>
                {
                    Session["MemberID"] = c.username;
                    Session["fullname"] = c.full_name;
                    Session["role"] = "admin";
                    //Session["status"] = c.account_status;
                });
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid Credentials'); </script>");
            }
        }
    }
}