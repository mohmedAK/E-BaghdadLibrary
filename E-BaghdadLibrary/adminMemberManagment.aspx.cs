using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELibrary.Controller;
using ELibrary.Model;
namespace ELibrary
{
    public partial class adminMemberManagment : System.Web.UI.Page
    {
        CMD_MemberMaster CMD_Member = new CMD_MemberMaster();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void LinkButtonGo_Click(object sender, EventArgs e)
        {
            GetMember();
        }
        //Active
        protected void LinkButtonCheck_Click(object sender, EventArgs e)
        {
            UpdateMemberStatus("Active");
            GetMember();
            GridView1.DataBind();
        }
        //pending
        protected void LinkButtonPause_Click(object sender, EventArgs e)
        {
            UpdateMemberStatus("Pending");
            GetMember();
            GridView1.DataBind();
        }
        //deactive
        protected void LinkButtonTimes_Click(object sender, EventArgs e)
        {
            UpdateMemberStatus("Deactivates");
            GetMember();
            GridView1.DataBind();
        }

        protected void ButtonDeleteUser_Click(object sender, EventArgs e)
        {
            DeleteMember();
        }

        void GetMember()
        {
            List<CLS_MemberMaster> member = CMD_Member.GetAllMemberMaster().Where(c => c.member_id == TextBoxMemberID.Text.Trim()).ToList();

            if (member.Count >= 1)
            {
                member.ForEach(c =>
                {
                    TextBoxFullName.Text = c.full_name;
                    TextBoxDOB.Text = c.dob;
                    TextBoxCity.Text = c.city;
                    TextBoxAccountStatus.Text = c.account_status;
                    TextBoxContactNo.Text = c.contact_no;
                    TextBoxEmailID.Text = c.email;
                    TextBoxFullPostalAddress.Text = c.full_address;
                    TextBoxPinCode.Text = c.pincode;
                    TextBoxState.Text = c.state;

                });
            }
            else
            {
                Response.Write("<script>alert('Member Id is not Exist'); </script>");
            }
      
        }

        void UpdateMemberStatus(string status)
        {
            CLS_MemberMaster memberMaster = new CLS_MemberMaster()
            {
                member_id = TextBoxMemberID.Text,
                account_status = status
            };
            CMD_Member.UpdateMemberStatus(memberMaster);
        }

        void DeleteMember()
        {
            CLS_MemberMaster memberMaster = new CLS_MemberMaster()
            {
                member_id = TextBoxMemberID.Text,
                 
            };
            CMD_Member.DeleteMember(memberMaster);
            ClearForm();
        }

        void ClearForm()
        {
            TextBoxMemberID.Text = "";
            TextBoxFullName.Text = "";
            TextBoxDOB.Text = "";
            TextBoxCity.Text = "";
            TextBoxAccountStatus.Text = "";
            TextBoxContactNo.Text = "";
            TextBoxEmailID.Text = "";
            TextBoxFullPostalAddress.Text = "";
            TextBoxPinCode.Text = "";
            TextBoxState.Text = "";
        }
    }
}