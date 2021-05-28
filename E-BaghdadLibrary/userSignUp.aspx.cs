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
    public partial class userSignUp : System.Web.UI.Page
    {
        CMD_MemberMaster cmd_MemberMaster = new CMD_MemberMaster();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSignUp_Click(object sender, EventArgs e)
        {
            if (!isClear())
            {
                SignUp();
            }
          




        }

        bool isClear()
        {
            if (string.IsNullOrWhiteSpace(TextBoxFullName.Text) ||
                string.IsNullOrWhiteSpace(TextBoxDateOfBirth.Text) ||
                string.IsNullOrWhiteSpace(TextBoxContactNo.Text) ||
                string.IsNullOrWhiteSpace(TextBoxContactNo.Text) ||
                string.IsNullOrWhiteSpace(TextBoxEmailId.Text) ||
                string.IsNullOrWhiteSpace(DropDownListState.SelectedItem.Value) ||
                string.IsNullOrWhiteSpace(TextBoxCity.Text) ||
                string.IsNullOrWhiteSpace(TextBoxPinCode.Text) ||
                string.IsNullOrWhiteSpace(TextBoxFullAddress.Text) ||
                string.IsNullOrWhiteSpace(TextBoxMemberId.Text) ||
                string.IsNullOrWhiteSpace(TextBoxPassword.Text) 
              
                )
            {
                Response.Write("<script>alert('Please Fill All data'); </script>");
                return true;
            }
            else
            {
                return false;
            }
            
        }

        void SignUp()
        {
            List<CLS_MemberMaster> members = cmd_MemberMaster.GetAllMemberMaster().Where(c => c.member_id == TextBoxMemberId.Text.Trim()).ToList();
            if (members.Count >= 1)
            {
                Response.Write("<script>alert('Member Id Already Existing'); </script>");
            }
            else
            {


                CLS_MemberMaster memberMaster = new CLS_MemberMaster()
                {
                    full_name = TextBoxFullName.Text.Trim(),
                    dob = TextBoxDateOfBirth.Text.Trim(),
                    contact_no = TextBoxContactNo.Text.Trim(),
                    email = TextBoxEmailId.Text.Trim(),
                    state = DropDownListState.SelectedItem.Value.Trim(),
                    city = TextBoxCity.Text.Trim(),
                    pincode = TextBoxPinCode.Text.Trim(),
                    full_address = TextBoxFullAddress.Text.Trim(),
                    member_id = TextBoxMemberId.Text.Trim(),
                    password = TextBoxPassword.Text.Trim(),
                    account_status = "pending"
                };
                if (cmd_MemberMaster.InsertMemberMaster(memberMaster))
                {
                    Response.Write("<script>alert('Sign Up Successful.Go to User Login to Login'); </script>");
                }
                else
                {
                    Response.Write("<script>alert('Sign Up Error'); </script>");
                }
            }

        }


    }
}