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
    public partial class userProfile : System.Web.UI.Page
    {
        CMD_MemberMaster CMD_Member = new CMD_MemberMaster();
        CMD_BookIssue CMD_BookIssue = new CMD_BookIssue();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["MemberID"].ToString() =="" || Session["MemberID"].ToString() == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("UserLogin.aspx");
                }
                else
                {
                    loadIssueInfo();
                    if (!Page.IsPostBack)
                    {
                        loadMemberInfo();
                    }
                }
            }
            catch (Exception)
            {

                
            }
        }

        void loadIssueInfo()
        {
          

            GridView1.DataSource = CMD_BookIssue.GetAllIssuingBooks().Where(c=> c.member_id == Session["MemberID"].ToString()).ToList();
            GridView1.DataBind();
        }

        void loadMemberInfo()
        {
            List<CLS_MemberMaster> member = CMD_Member.GetAllMemberMaster().Where(c => c.member_id == Session["MemberID"].ToString()).ToList();

            member.ForEach(c =>
            {
                LabelStatius.Text = c.account_status;
                TextBoxFullName.Text = c.full_name;
                TextBoxFullAddress.Text = c.full_address;
                TextBoxDateOfBirth.Text = c.dob;
                TextBoxEmailID.Text = c.email;
                TextBoxPincode.Text = c.pincode;
                TextBoxUserID.Text = c.member_id;
                TextBoxOldPassword.Text = c.password;
                TextBoxCity.Text = c.city;
                DropDownListState.SelectedValue = c.state;
                TextBoxContactNo.Text = c.contact_no;

                if (c.account_status == "Active")
                {
                    LabelStatius.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (c.account_status == "Pending")
                {
                    LabelStatius.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (c.account_status == "Deactivates")
                {
                    LabelStatius.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    LabelStatius.Attributes.Add("class", "badge badge-pill badge-info");
                }



            });
        }
        void updateUserPersonalDetails()
        {
            string password = "";
            if (TextBoxNewPassword.Text.Trim() == "")
            {
                password = TextBoxOldPassword.Text.Trim();
            }
            else
            {
                password = TextBoxNewPassword.Text.Trim();
            }
            CLS_MemberMaster memberMaster = new CLS_MemberMaster()
            {
                full_name = TextBoxFullName.Text.Trim(),
                dob = TextBoxDateOfBirth.Text.Trim(),
                contact_no = TextBoxContactNo.Text.Trim(),
                email = TextBoxEmailID.Text.Trim(),
                state = DropDownListState.SelectedItem.Value.Trim(),
                city = TextBoxCity.Text.Trim(),
                pincode = TextBoxPincode.Text.Trim(),
                full_address = TextBoxFullAddress.Text.Trim(),
                member_id = Session["MemberID"].ToString(),
                password = password,
                account_status= "Pending"
            };
            if (CMD_Member.UpdateMemberMaster(memberMaster))
            {
                Response.Write("<script>alert('Your Detail Update Successfully');</script>");
                loadIssueInfo();
                loadMemberInfo();
            }
            else
            {
                Response.Write("<script>alert('Invalid Entry');</script>");
            }
        }
            protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[4].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (Session["MemberID"].ToString() == "" || Session["MemberID"].ToString() == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("UserLogin.aspx");
            }
            else
            {
                updateUserPersonalDetails();
            }
        }
    }
}