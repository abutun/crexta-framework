using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Text;
using Crexta.Utilities;

namespace Crexta.Live
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
            contactForm.Subject = "crexta.com - İletişim formu";

            EmailUtility.SendMailMessage(contactForm);

            this.resultLabel.Text = "Mesajınız başarıyla iletildi. En kısa zamanda sizinle temasa geçeceğiz. Teşekkürler.";
        }
    }
}