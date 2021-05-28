using ELibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELibrary.Controller;
 
namespace ELibrary
{
    public partial class adminPublisherManagment : System.Web.UI.Page
    {
        CMD_PublisherMaster CMD_Publisher = new CMD_PublisherMaster();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            List<CLS_PublisherMaster> Publishers = CMD_Publisher.GetAllPublisher().Where(c => c.publisher_id == TextBoxPublisherID.Text.Trim()).ToList();
            if (Publishers.Count >= 1)
            {
                Publishers.ForEach(c =>
                {
                    TextBoxPublisherName.Text = c.publisher_name;
                });
            }
            else
            {
                Response.Write("<script>alert('Publisher Id is not Exist'); </script>");
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (isPublisherExists())
            {
                Response.Write("<script>alert('Publisher Id Already Existing Enter Another Publisher Id'); </script>");
            }
            else
            {
                AddPublisher();
                Response.Write("<script>alert('Add Publisher successfully'); </script>");
                ClearForm();
                GridView1.DataBind();
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (isPublisherExists())
            {
                UpdatePublisher();
                Response.Write("<script>alert('Publisher Name Update successfully'); </script>");
                ClearForm();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Publisher Id is not Exist'); </script>");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (isPublisherExists())
            {
                DeletePublisher();
                Response.Write("<script>alert('Publisher Name Delete successfully'); </script>");
                ClearForm();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Publisher Id is not Exist'); </script>");
            }
        }




        bool isPublisherExists()
        {
            List<CLS_PublisherMaster> Publishers = CMD_Publisher.GetAllPublisher().Where(c => c.publisher_id == TextBoxPublisherID.Text.Trim()).ToList();
            if (Publishers.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void AddPublisher()
        {
            CLS_PublisherMaster Publisher = new CLS_PublisherMaster()
            {
                
                publisher_id = TextBoxPublisherID.Text.Trim(),
                publisher_name= TextBoxPublisherName.Text.Trim()
            };

            CMD_Publisher.InsertPublisher(Publisher);
        }

        void UpdatePublisher()
        {
            CLS_PublisherMaster Publisher = new CLS_PublisherMaster()
            {

                publisher_id = TextBoxPublisherID.Text.Trim(),
                publisher_name = TextBoxPublisherName.Text.Trim()
            };

            CMD_Publisher.UpdatePublisher(Publisher);
        }

        void DeletePublisher()
        {
            CLS_PublisherMaster Publisher = new CLS_PublisherMaster()
            {

                publisher_id = TextBoxPublisherID.Text.Trim(),
                publisher_name = TextBoxPublisherName.Text.Trim()
            };
            CMD_Publisher.DeletePublisher(Publisher);
        }

        void ClearForm()
        {
            TextBoxPublisherID.Text = "";
            TextBoxPublisherName.Text = "";
        }

    }
}