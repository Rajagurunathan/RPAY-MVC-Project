using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using AdminDashBoard;
using AdminDashBoard.Models;


namespace AdminDashBoard.Controllers
{
    public class AdminLoginController : Controller
    {
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        string sqlmaincon = ConfigurationManager.ConnectionStrings["mainconRC"].ConnectionString;
        // GET: AdminLogin
        public ActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminLogin admin)
        {

            try
            {
                con = new SqlConnection(sqlmaincon);
                con.Open();
                cmd = new SqlCommand("select * from Admin where admin_name=@admin_name and admin_password=@admin_password",con);
                cmd.Parameters.AddWithValue("@admin_name", admin.admin_name);
                cmd.Parameters.AddWithValue("@admin_password", admin.admin_password);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Session["adminkey"] = admin.admin_id.ToString();
                    Session["adminid"] = admin.admin_name;
                    con.Close();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    con.Close();
                    return RedirectToAction("Index", "Home");
                }
            
            }
            catch (Exception)
            {
                return RedirectToAction("Sign_up", "Home");
            }


        }
    }
}