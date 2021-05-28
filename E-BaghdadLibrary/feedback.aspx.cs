using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using ELibrary.Model;
using ELibrary.Controller;
using System.Configuration;

namespace ELibrary
{
    public partial class feedback : System.Web.UI.Page
    {
        CMD_Feedback CMD_Feedback = new CMD_Feedback();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (TextBoxEmailID.Text =="" ||TextBoxFullfeedback.Text ==""||TextBoxName.Text == "")
            {
                Response.Write("Please Full All data");
            }
            else
            {
                //CLS_Feedback feed = new CLS_Feedback()
                //{
                //    username = TextBoxName.Text,
                //    email = TextBoxEmailID.Text,
                //    feed = TextBoxFullfeedback.Text
                //};
                //CMD_Feedback.InsertFeedback(feed);
                //Response.Write("<script>alert('Feedback added successfully'); </script>");
                //Response.Redirect("HomePage.aspx");
                string sendEmail = ConfigurationManager.AppSettings["SendEmail"];
                if (sendEmail.ToLower() == "true")
                {
                    SendEmail();
                }
                
            }
        }

        void SendEmail()
        {
            try
            {
                MailMessage mailMessage = new MailMessage(TextBoxEmailID.Text.Trim(), "Ali.Zyer84@gmail.com");
                mailMessage.Subject = "Exception";
                mailMessage.Body = TextBoxFullfeedback.Text.Trim();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = "Ali.Zyer84@gmail.com",
                    Password = "Aa22446688"
                };
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
            }
            catch (Exception)
            {

                
            }
           
        }
    }
}