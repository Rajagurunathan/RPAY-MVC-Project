using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using online_recharge_system.Models;

namespace online_recharge_system.Controllers
{
    public class PasswordResetController : Controller
    {
        // GET: PasswordReset
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        string sqlmaincon = ConfigurationManager.ConnectionStrings["mainconRC"].ConnectionString;
        public ActionResult Reset()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (Global.otp == null)
            {
                return RedirectToAction("SendOtp", "PasswordReset");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Reset(PasswordReset pwd)
        {
            try
            {
                if(Global.otp==pwd.otp)
                {
                con = new SqlConnection(sqlmaincon);
                con.Open();
                cmd = new SqlCommand("UPDATE Users SET password=@pass WHERE email=@email", con);
                cmd.Parameters.AddWithValue("@pass", pwd.c_password);
                cmd.Parameters.AddWithValue("@email", pwd.email);
                cmd.ExecuteNonQuery();
                con.Close();

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("minnanjal2500@gmail.com", "300999@krr");
                smtp.EnableSsl = true;
                MailMessage mm = new MailMessage();
                mm.Subject = "PASSWORD CHANGED SUCCESSFULLY";
                mm.Body = "Dear " + "Customer " + "Your Password Has been SuccessFully Changed.\nThanks";
                mm.To.Add(pwd.email);
                string frmailaddress = "minnanjal2500@gmail.com";
                mm.From = new MailAddress(frmailaddress,"Rpay");
                try
                {
                    smtp.Send(mm);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return RedirectToAction("ULogin", "UserLogin");
        }
        public ActionResult SendOtp()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (Global.otp != null)
            {
                Global.otp = null;
                return RedirectToAction("SendOtp", "PasswordReset");
            }
            return View();
        }
        [HttpPost]
        public ActionResult SendOtp(PasswordReset pwd)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("minnanjal2500@gmail.com", "300999@krr");
                smtp.EnableSsl = true;
                MailMessage mm = new MailMessage();
                mm.Subject = "Rpay!!!OTP ALERT";
                Random rn = new Random();
                Global.otp = rn.Next(10000, 99999).ToString();
                mm.Body = "Dear " + "Customer " + "Your Otp " + Global.otp + " Thanks";
                mm.To.Add(pwd.email);
                string frmailaddress = "minnanjal2500@gmail.com";
                mm.From = new MailAddress(frmailaddress,"Rpay");
                try
                {
                    smtp.Send(mm);
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return RedirectToAction("Reset","PasswordReset");
        }
    }
}