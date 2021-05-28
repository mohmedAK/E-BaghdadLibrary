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
    public partial class UserLogin : System.Web.UI.Page
    {
        CMD_MemberMaster CMD_Member = new CMD_MemberMaster();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxMemberID.Text) || string.IsNullOrWhiteSpace(TextBoxPassword.Text))
            {
                Response.Write("<script>alert('Please Fill Username or Password Field'); </script>");
                return;
            }
            login();
        }

        void login()
        {
            List<CLS_MemberMaster> member = CMD_Member.GetAllMemberMaster().Where(c => c.member_id == TextBoxMemberID.Text.Trim() && c.password==TextBoxPassword.Text.Trim()).ToList();
            if (member.Count >= 1)
            {
                member.ForEach(c =>
                {
                    Session["MemberID"] = c.member_id;
                    Session["fullname"] = c.full_name;
                    Session["role"] = "user";
                    Session["status"] = c.account_status;
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