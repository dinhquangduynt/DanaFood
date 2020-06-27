using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ThucPham.Common
{
    public class MailHelper
    {
        public static bool SendMail(string toEmail, string subject, string content)
        {
            try
            {
                var fromAddress = new MailAddress("danafoodsp@gmail.com", "From Name");
                var toAddress = new MailAddress(toEmail, "To Name");
                const string fromPassword = "Quangduy98!";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = content
                })
                {
                    smtp.Send(message);
                }
                return true;
            }
            catch (SmtpException smex)
            {

                return false;
            }
        }
    }
}