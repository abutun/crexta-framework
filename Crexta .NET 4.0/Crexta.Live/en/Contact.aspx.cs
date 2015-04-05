using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using Crexta.Utilities;
using System.Text;

namespace Crexta.Live.en
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control control = this.Master.FindControl("topLinkContact");
            if (control != null)
            {
                HtmlGenericControl topLink = (HtmlGenericControl)control;
                topLink.Attributes.Add("class", "menu_active");
            }
        }

        protected void sendButton_Click(object sender, EventArgs e)
        {
            // Send email
            MailMessage contactForm = new MailMessage();

            contactForm.From = new MailAddress("admin@crexta.com");
            contactForm.To.Add("ahmetbutun@gmail.com");
            contactForm.To.Add("ahmet@abbsolutions.com");
            contactForm.IsBodyHtml = true;
            contactForm.BodyEncoding = Encoding.UTF8;
            contactForm.Body = EmailUtility.GetCrextaContactFormEmailTemplate(this.messageTextBox.Text,
                                                                        this.nameTextBox.Text,
                                                                        this.emailTextBox.Text,
                                                                        this.phoneTextBox.Text);
            contactForm.Subject = "crexta.com - Contact form";

            EmailUtility.SendMailMessage(contactForm);

            this.resultLabel.Text = "Your message was successfully delivered. We will contact you soon. Thank you.";
        }
    }
}