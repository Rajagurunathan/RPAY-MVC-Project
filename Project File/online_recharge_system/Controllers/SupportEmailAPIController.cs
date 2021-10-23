using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using online_recharge_system.Models;

namespace online_recharge_system.Controllers
{
    public class SupportEmailAPIController : ApiController
    {
        public IHttpActionResult sendmail(SupportEmail ec)
        {
            string otp;
            string subject = ec.subject;
            string body = ec.body;
            string to = ec.to;
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("minnanjal2500@gmail.com","Rpay-Support-Team");
            Random rn = new Random();
            otp = rn.Next(10000, 99999).ToString();
            mm.To.Add(to);
            mm.Subject = "Alert !!!"+subject;
            mm.Body = "Dear Customer \n Your Support ID="+otp+"\n\t\tYour following Query \n\t\t\t\t\t"+body+"\n\t\tHas Forwarded To Our Support Team" +
                      "\n\t\t\tYou Will get Response Within 24 hours\nWith Regards,\nRpay Team.";
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = true;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("minnanjal2500@gmail.com", "300999@krr");
            smtp.Send(mm);
            return Ok();
        }
    }
}
