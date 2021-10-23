using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using online_recharge_system.Models;

namespace online_recharge_system.Controllers
{
    public class UserLoginController : Controller
    {
        public SqlConnection con;
        public SqlCommand cmd,cmd1,cmd2;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        string sqlmaincon = ConfigurationManager.ConnectionStrings["mainconRC"].ConnectionString;
        // GET: AdminLogin
        public ActionResult ULogin()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["UserID"] = null;
            Session.Abandon();
            Session.RemoveAll();
            Global.otp = null;
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult ULogin(UserLogin user)
        {
            try
            {
                string email1 = user.email;
                con = new SqlConnection(sqlmaincon);
                con.Open();
                cmd = new SqlCommand("select * from Users where email=@email and password=@password",con);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@password", user.password);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    cmd1 = new SqlCommand("select userid from Users where email='" + email1 + "'", con);
                    cmd1.ExecuteScalar();
                  //  Global.Userkey = cmd1.ExecuteScalar().ToString();
                    Session["UserKey"]= cmd1.ExecuteScalar().ToString();
                    
                    Session["UserID"] = user.email;
                  //  Global.UserID= Session["username"].ToString();
                   // Global.Userkey = Session["userid"].ToString();
                    con.Close();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    con.Close();
                    return RedirectToAction("Index", "Home");
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}