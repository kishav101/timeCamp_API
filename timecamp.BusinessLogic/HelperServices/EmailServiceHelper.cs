
using System.Net.Mail;
using System.Net;
using System.Text;
using timeCamp.CommonLogic.Interfaces;

namespace timecamp.BusinessLogic.HelperServices
{
    public class EmailServiceHelper: IEmailService
    {
        private SmtpClient smtpClient = new SmtpClient("smtp.mail.yahoo.com", 465);
        private MailMessage mailMessage = new MailMessage();

        public EmailServiceHelper() 
        {
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("Kishav100@yahoo.com", "673725Ab");
        }

        public void SendEmail(string toEmail, string subject)
        {
            mailMessage.From = new MailAddress("Kishav100@Yahoo.com");
            mailMessage.Subject = subject;
            mailMessage.To.Add(toEmail);
            mailMessage.IsBodyHtml = true;

            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<h1>Hello, from Email</h1>");
            mailBody.AppendFormat("<br/>");
            mailBody.AppendFormat("<p>Thank you for registering with us</p>");

            mailMessage.Body = mailBody.ToString();
            smtpClient.Send(mailMessage);
        }
    }
}
