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
    public partial class adminBookIssuing : System.Web.UI.Page
    {
        CMD_BookMaster CMD_Book = new CMD_BookMaster();
        CMD_MemberMaster CMD_Member = new CMD_MemberMaster();
        CMD_BookIssue CMD_BookIssue = new CMD_BookIssue();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonIssue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxBookID.Text) || string.IsNullOrWhiteSpace(TextBoxMemberID.Text))
            {
                Response.Write("<script>alert('Please Fill Book Id And Member Id Field'); </script>");
                return;
            }
            if (isBookExist() && isMemberExist())
            {
                if (isIssueEntryExist())
                {
                    Response.Write("<script>alert('This Member already has this book'); </script>");
                }
                else
                {
                    issueBook();
                    GridView1.DataBind();
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong Book Id Or Member ID'); </script>");
            }
        }

        protected void ButtonReturn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxBookID.Text) || string.IsNullOrWhiteSpace(TextBoxMemberID.Text))
            {
                Response.Write("<script>alert('Please Fill Book Id And Member Id Field'); </script>");
                return ;
            }
            if (isBookExist() && isMemberExist())
            {
                if (isIssueEntryExist())
                {
                    ReturnBook();
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('This Entry does not Exist'); </script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong Book Id Or Member ID'); </script>");
            }
        }

        private void ReturnBook()
        {
            CLS_BookIssue issue = new CLS_BookIssue()
            {
                member_id = TextBoxMemberID.Text.Trim(),
                book_id = TextBoxBookID.Text.Trim()
            };
            CMD_BookIssue.DeleteIssueBookAndIncrementCuurenStock(issue);
        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            
            GetNames();
        }

        void GetNames()
        {
            List<CLS_BookMaster> books = CMD_Book.GetAllBooks().Where(c => c.book_id == TextBoxBookID.Text.Trim()).ToList();
            if (books.Count >= 1)
            {
                books.ForEach(c =>
                {
                    TextBoxBookName.Text = c.book_name;
                });
            }
            else
            {
                Response.Write("<script>alert('Book Id is not Existing Enter Another Book Id'); </script>");
            }

            List<CLS_MemberMaster> Member = CMD_Member.GetAllMemberMaster().Where(c => c.member_id == TextBoxMemberID.Text.Trim()).ToList();
            if (Member.Count >= 1)
            {
                Member.ForEach(c =>
                {
                    TextBoxMemberName.Text = c.full_name;
                });
            }
            else
            {
                Response.Write("<script>alert('Member Id is not Existing Enter Another Member Id'); </script>");
            }
        }

        bool isBookExist()
        {
            
            List<CLS_BookMaster> books = CMD_Book.GetAllBooks().Where(c => c.book_id == TextBoxBookID.Text.Trim() && int.Parse(c.current_stock) > 0).ToList();
            if (books.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool isMemberExist()
        {
            List<CLS_MemberMaster> Member = CMD_Member.GetAllMemberMaster().Where(c => c.member_id == TextBoxMemberID.Text.Trim()).ToList();
            if (Member.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void issueBook()
        {
            CLS_BookIssue issue = new CLS_BookIssue()
            {
                book_id = TextBoxBookID.Text.Trim(),
                member_id = TextBoxMemberID.Text.Trim(),
                book_name = TextBoxBookName.Text.Trim(),
                member_name =TextBoxMemberName.Text.Trim(),
                issue_date =TextBoxStartDate.Text.Trim(),
                due_date =TextBoxEndDate.Text.Trim()
            };
            CMD_BookIssue.InsertBookIssue(issue);

            CMD_Book.SubCurrentStock(TextBoxBookID.Text.Trim());

        }


        bool isIssueEntryExist()
        {
            List<CLS_BookIssue> issue = CMD_BookIssue.GetAllIssuingBooks().Where(c => c.member_id == TextBoxMemberID.Text && c.book_id ==TextBoxBookID.Text.Trim()).ToList();
            if (issue.Count >= 1)
            {
                return true;
            }
            return false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
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
    }
}