using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using online_recharge_system.Models;
using HtmlHelper = System.Web.WebPages.Html.HtmlHelper;

namespace online_recharge_system.Controllers
{
    public class UserRegistrationController : Controller
    {
        public SqlConnection con;
        public SqlCommand cmd,cmd1;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        string sqlmaincon = ConfigurationManager.ConnectionStrings["mainconRC"].ConnectionString;
        // GET: UserRegistration
        public ActionResult Sign_up()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Error()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Sign_up(UserRegistration user)
        {
            int balance = 0;
              try
              {
                  con = new SqlConnection(sqlmaincon);
                  con.Open();
                  cmd1 = new SqlCommand("select * from Users where email=@email", con);
                  cmd1.Parameters.AddWithValue("@email", user.email);
                  dr = cmd1.ExecuteReader();
                  if (dr.Read())
                  {
                      dr.Close();
                      con.Close();
                      ViewBag.usererror = "USER EXISTS";
                      return RedirectToAction("Error", "UserRegistration");
                  }
                  dr.Close();
                  cmd = new SqlCommand("insert into Users(name,phone_number,email,dob,city,state,pincode,password,balance) values(@name,@phone_number,@email,@dob,@city,@state,@pincode,@password,@balance)", con);
                  cmd.Parameters.AddWithValue("@name", user.name);
                  cmd.Parameters.AddWithValue("@phone_number", user.phone_number);
                  cmd.Parameters.AddWithValue("@email", user.email);
                  cmd.Parameters.AddWithValue("@dob", user.dob);
                  cmd.Parameters.AddWithValue("@city", user.city);
                  cmd.Parameters.AddWithValue("@state", user.state);
                  cmd.Parameters.AddWithValue("@pincode", user.pincode);
                  cmd.Parameters.AddWithValue("@password", user.c_password);
                  cmd.Parameters.AddWithValue("@balance", balance);
                  cmd.ExecuteNonQuery();
                  con.Close();
                  SmtpClient smtp = new SmtpClient();
                  smtp.Host = "smtp.gmail.com";
                  smtp.Port = 587;
                  smtp.Credentials = new System.Net.NetworkCredential("minnanjal2500@gmail.com", "300999@krr");
                  smtp.EnableSsl = true;
                  MailMessage mm = new MailMessage();
                  mm.Subject = "Rpay!!!ACCOUNT CREATION SUCCESSFUL!!";
                  mm.Body = "Dear " + "Customer " + "Your Account Has been SuccessFully Created.\nThanks";
                  mm.To.Add(user.email);
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
                return RedirectToAction("ULogin", "UserLogin");
              }
              catch (Exception)
              {
                  return RedirectToAction("Sign_up", "UserRegistration");
              }
        }
    }
}