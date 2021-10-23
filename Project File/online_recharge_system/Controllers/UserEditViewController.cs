using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using online_recharge_system.Models;
using online_recharge_system;
namespace online_recharge_system.Controllers
{
    public class UserEditViewController : Controller
    {
        public SqlConnection con;
        public SqlCommand cmd, cmd2;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        string sqlmaincon = ConfigurationManager.ConnectionStrings["mainconRC"].ConnectionString;
        // GET: UserEditView
        public ActionResult EditUser()
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
            mainconRCEntities entities = new mainconRCEntities();
            List<User> userlist = entities.Users.ToList();
            return View(userlist.Find(m=>m.userid==Convert.ToInt32(Session["UserKey"])));
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            try
            {
                con = new SqlConnection(sqlmaincon);
                con.Open();
                cmd = new SqlCommand("Update Users set name=@name,phone_number=@phone_number,city=@city,state=@state,pincode=@pincode where userid=@uid", con);
                cmd.Parameters.AddWithValue("@name", user.name);
                cmd.Parameters.AddWithValue("@phone_number", user.phone_number);
                cmd.Parameters.AddWithValue("@city", user.city);
                cmd.Parameters.AddWithValue("@state", user.state);
                cmd.Parameters.AddWithValue("@pincode", user.pincode);
                cmd.Parameters.AddWithValue("@uid", Session["UserKey"]);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("EditUser", "UserEditView");
        }
    }
}