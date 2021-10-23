using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using online_recharge_system.Models;

namespace online_recharge_system.Controllers
{
    public class EmailOtpController : Controller
    {
        // public string otp;
        // GET: EmailOtp
        public ActionResult Index()
        {
            return View();
        }

        /*[HttpPost]
        public ActionResult SendOtp()
        {
            SmtpClient smtp =new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials =new System.Net.NetworkCredential("minnanjal2500@gmail.com","300999@krr");
            smtp.EnableSsl = true;
            MailMessage mm =new MailMessage();
            mm.Subject = "OTP ALERT";
            Random rn =new Random();
            otp = rn.Next(10000, 99999).ToString();
            ViewBag.otdata = otp;
            mm.Body="Dear " + "Customer " + "Your Otp " + otp + " Thanks";
            mm.To.Add(Global.UserID);
            string frmailaddress = "minnanjal2500@gmail.com";
            mm.From =new MailAddress(frmailaddress);
            try
            {
                smtp.Send(mm);
            }
            catch(Exception)
            {
                return View();
            }

            return RedirectToAction("Index","EmailOtp");

        }*/
    }
}