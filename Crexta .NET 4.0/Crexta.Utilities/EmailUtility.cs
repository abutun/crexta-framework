/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*	CREXTA - Web Data Extraction Framework  							*
*																		*
*	Copyright (C) 2009-2011  Ahmet BÜTÜN (ahmetbutun@gmail.com)			*
*	http://www.ahmetbutun.net |	http://www.abbsolutions.com				*
*																		*
*	www.me-like.biz														*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading;

namespace Crexta.Utilities
{
    public class EmailUtility
    {
        public static event EventHandler<EventArgs> EmailSent;

        public static event EventHandler<EventArgs> EmailFailed;

        #region Send e-mail

        /// <summary>
        /// Sends a MailMessage object using the SMTP settings.
        /// </summary>
        public static void SendMailMessage(MailMessage message)
        {
            if (message == null)
                throw new ArgumentNullException();

            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");

                smtp.Credentials = new System.Net.NetworkCredential("no-reply@crexta.com", "Maya3426");

                smtp.Port = 587;

                smtp.EnableSsl = true;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(message);

                smtp.Timeout = 20000;

                OnEmailSent(message);
            }
            catch (SmtpException)
            {
                OnEmailFailed(message);
            }
            finally
            {
                // Remove the pointer to the message object so the GC can close the thread.
                message.Dispose();

                message = null;
            }
        }

        /// <summary>
        /// Sends the mail message asynchronously in another thread.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public static void SendMailMessageAsync(MailMessage message)
        {
            ThreadPool.QueueUserWorkItem(delegate { SendMailMessage(message); });
        }

        /// <summary>
        /// Occurs after an e-mail has been sent. The sender is the MailMessage object.
        /// </summary>
        private static void OnEmailSent(MailMessage message)
        {
            if (EmailSent != null)
            {
                EmailSent(message, new EventArgs());
            }
        }

        /// <summary>
        /// Occurs after an e-mail has been sent. The sender is the MailMessage object.
        /// </summary>
        private static void OnEmailFailed(MailMessage message)
        {
            if (EmailFailed != null)
            {
                EmailFailed(message, new EventArgs());
            }
        }

        public static string CrextorErrorMessage(string title, string name, string surname, string link)
        {
            string res = "";

            res = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">";
            res = res + @"<html xmlns=""http://www.w3.org/1999/xhtml"">";
            res = res + @"<head>";
            res = res + @"<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />";
            res = res + @"<title>crexta.com - Yeni mesajınız var!</title>";
            res = res + @"</head>";
            res = res + @"<body>";
            res = res + @"<p>Sayın <strong>" + name + "</strong> <strong>" + surname + "</strong>,</p>";
            res = res + @"<p><strong>" + title + "</strong> adlı başlığınız onaylanmıştır. Başlığı görmek ve başlığa entry eklemek için lütfen aşağıdaki linki tıklayınız.<br />";
            res = res + @"" + link + "</p>";
            res = res + @"<p>teşekkürler,<br />";
            res = res + @"<strong>crexta.com</strong></p>";
            res = res + @"</body>";
            res = res + @"</html>";

            return res;
        }

        public static string GetCrextaContactFormEmailTemplate(string content, string name, string email, string phone)
        {
            string res = "";

            res = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">";
            res = res + @"<html xmlns=""http://www.w3.org/1999/xhtml"">";
            res = res + @"<head>";
            res = res + @"<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />";
            res = res + @"<title>crexta.com - Crawl and Extract Data</title>";
            res = res + @"</head>";
            res = res + @"<body>";
            res = res + @"<p>Sayın <strong>yönetici</strong>,</p>";
            res = res + @"<p>crexta.com iletişim formu üzerinden aşağıdaki bilgileri gönderilmiştir.<br />";
            res = res + @"<br/>";
            res = res + @"<strong>Ad:</strong>" + name + "<br/>";
            res = res + @"<strong>Eposta:</strong>" + email + "<br/>";
            res = res + @"<strong>Telefon:</strong>" + phone + "<br/>";
            res = res + @"<strong>Mesaj:</strong>" + content + "<br/>";
            res = res + @"<br/>";
            res = res + @"<p>teşekkürler,<br />";
            res = res + @"<strong>crexta.com</strong></p>";
            res = res + @"</body>";
            res = res + @"</html>";

            return res;
        }

        #endregion
    }
}
