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
    public partial class adminAuthorManagement : System.Web.UI.Page
    {
        CMD_AuthorMaster CMD_Author = new CMD_AuthorMaster();
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (isAuthorExists())
            {
                Response.Write("<script>alert('Author Id Already Existing Enter Another Author Id'); </script>");
            }
            else
            {
                AddAuthor();
                //Response.Write("<script>alert('Add Author successfully'); </script>");
                ClearForm();
                GridView1.DataBind();
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (isAuthorExists())
            {
                UpdateAuthor();
                Response.Write("<script>alert('Author Name Update successfully'); </script>");
                ClearForm();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Author Id is not Exist'); </script>");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (isAuthorExists())
            {
                DeleteAuthor();
                Response.Write("<script>alert('Author Name Delete successfully'); </script>");
                ClearForm();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Author Id is not Exist'); </script>");
            }
        }


        bool isAuthorExists()
        {
            if (string.IsNullOrWhiteSpace(TextBoxAuthorId.Text))
            {
                Response.Write("<script>alert('Author Id is not Exist'); </script>");
                return false;
            }
           
            List<CLS_AuthorMaster> Authors = CMD_Author.GetAllAuthor().Where(c => c.author_id == TextBoxAuthorId.Text.Trim()).ToList();
            if (Authors.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void AddAuthor()
        {

            if (string.IsNullOrWhiteSpace(TextBoxAuthorId.Text) || string.IsNullOrWhiteSpace(TextBoxAuthorName.Text))
            {
                Response.Write("<script>alert('Please Fill All Text Box'); </script>");
                return;
            }
            CLS_AuthorMaster Author = new CLS_AuthorMaster()
            {
                author_id =TextBoxAuthorId.Text.Trim(),
                author_name =TextBoxAuthorName.Text.Trim()
            };

            CMD_Author.InsertAuthor(Author);
        }

        void UpdateAuthor()
        {
            if (string.IsNullOrWhiteSpace(TextBoxAuthorId.Text) || string.IsNullOrWhiteSpace(TextBoxAuthorName.Text))
            {
                Response.Write("<script>alert('Please Fill All Text Box'); </script>");
                return;
            }
            CLS_AuthorMaster Author = new CLS_AuthorMaster()
            {
                author_id = TextBoxAuthorId.Text.Trim(),
                author_name = TextBoxAuthorName.Text.Trim()
            };

            CMD_Author.UpdateAuthor(Author);
        }

        void DeleteAuthor()
        {

            CLS_AuthorMaster Author = new CLS_AuthorMaster()
            {
                author_id = TextBoxAuthorId.Text.Trim(),
                author_name = TextBoxAuthorName.Text.Trim()
            };
            CMD_Author.DeleteAuthor(Author);
        }

        void ClearForm()
        {
            TextBoxAuthorId.Text = "";
            TextBoxAuthorName.Text = "";
        }

        

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            if ( string.IsNullOrWhiteSpace(TextBoxAuthorId.Text.Trim()))
            {
                Response.Write("<script>alert('Author Id is not Exist'); </script>");
            }
            else
            {
                List<CLS_AuthorMaster> Authors = CMD_Author.GetAllAuthor().Where(c => c.author_id == TextBoxAuthorId.Text.Trim()).ToList();
                if (Authors.Count >= 1)
                {
                    Authors.ForEach(c =>
                    {
                        TextBoxAuthorName.Text = c.author_name;
                    });
                }
                else
                {
                    Response.Write("<script>alert('Author Id is not Exist'); </script>");
                }
            }
            
        }
    }
}