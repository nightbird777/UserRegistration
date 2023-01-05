using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistration.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace UserRegistration.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user, HttpPostedFileBase file)
        {
            string mainConn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection connection= new SqlConnection(mainConn);
            string sql = "insert into [dbo].[Registration] (FirstName, LastName, Image) values (@FirstName, @LastName, @Image)";
            SqlCommand cmd= new SqlCommand(sql, connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            
            if (file != null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string imgPath = Path.Combine(Server.MapPath("~/App_Data/Image/"), fileName);
                file.SaveAs(imgPath);
            }
            cmd.Parameters.AddWithValue("@Image", "~/App_Data/Image/" + file.FileName);
            cmd.ExecuteNonQuery();
            connection.Close();
            ViewData["Message"] = "User Record " + user.FirstName + " " + user.LastName + " is saved Successfully!!!";
            return View();
        }
    }
}