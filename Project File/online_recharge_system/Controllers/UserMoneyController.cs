using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.codec;
using online_recharge_system.Models;

namespace online_recharge_system.Controllers
{
    public class UserMoneyController : Controller
    {
        public SqlConnection con;
        public SqlCommand cmd,cmd2;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        string sqlmaincon = ConfigurationManager.ConnectionStrings["mainconRC"].ConnectionString;
        // GET: UserMoney
        public ActionResult UserMoney()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("ULogin", "UserLogin");
            }
            if (Session["UserID"] != null)
            {
                con = new SqlConnection(sqlmaincon);
                con.Open();
                cmd2 = new SqlCommand("select balance from Users where userid='" + Session["Userkey"] + "'", con);
                cmd2.ExecuteScalar();
                ViewBag.bal = cmd2.ExecuteScalar().ToString();
                con.Close();

            }

            return View();
        }

        public ActionResult PaymentOtp()
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("minnanjal2500@gmail.com", "300999@krr");
                smtp.EnableSsl = true;
                MailMessage mm = new MailMessage();
                mm.Subject = "Rpay!!!PAYMENT ALERT";
                Random rn = new Random();
                Global.otp = rn.Next(10000, 99999).ToString();
                mm.Body = "Dear " + "User " + "Your Otp " + Global.otp + " Thanks";
                mm.To.Add(Session["UserID"].ToString());
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
            return View();
        }
    
        [HttpPost]
        public ActionResult UserMoney(UserMoney user)
        {
            try
            {
                con = new SqlConnection(sqlmaincon);
                con.Open();
                cmd = new SqlCommand("UPDATE Users SET balance=balance+@balance WHERE userid=@userid", con);
                cmd.Parameters.AddWithValue("@userid",Session["UserKey"]);
                cmd.Parameters.AddWithValue("@balance", user.addamount);
                cmd.ExecuteNonQuery();
                con.Close();

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("minnanjal2500@gmail.com", "300999@krr");
                smtp.EnableSsl = true;
                MailMessage mm = new MailMessage();
                mm.Subject = "Rpay!!!TRANSACTION ALERT";
                mm.Body = "Dear " + "Customer " + "Your Transcation of Rupees " + user.addamount +
                          " is Successfully Added to Your Wallet \nThanks";
                mm.To.Add(Session["UserID"].ToString());
                string frmailaddress = "minnanjal2500@gmail.com";
                mm.From = new MailAddress(frmailaddress,"Rpay");

                MemoryStream ms = new MemoryStream();
                Document doc = new Document(PageSize.A4, 10f, 10f, 100f, 0.0f);
                //require custom parsers? add here.
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open(); //open doc for editing

                doc.Add(new Paragraph("Dear " + "Customer\n " + "Your Transcation of Rupees " + user.addamount +
                                      " is Successfully Added to Your Wallet \nThanks"));
                //doc.Add(new Paragraph("Second Paragraph"));

                writer.CloseStream = false; //important
                doc.Close(); //build the doc.
                ms.Position = 0; //reset stream... important
                mm.Attachments.Add(new Attachment(ms, "Notice.pdf"));
                try
                {
                    smtp.Send(mm);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

    }
}