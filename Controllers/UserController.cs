using CarRentalSystem.DBModel;
using CarRentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace CarRentalSystem.Controllers
{
    public class UserController : Controller
    {
        SnapDriveDBEntities1 objSnapDBEntities=new SnapDriveDBEntities1();

        //SqlConnection conn = new SqlConnection();
        //SqlCommand com = new SqlCommand();
        //SqlDataReader dr;
        // GET: User
        public ActionResult Index()
        {
            return View("UserDesh");
        }

        public ActionResult Register()
        {
            UserModel objUserModel= new UserModel();
            return View(objUserModel);
     
        }
        [HttpPost]
        public ActionResult Register(UserModel objUserModel)
        {
            if (ModelState.IsValid)
            {
                User objUser = new DBModel.User();
                objUser.RegistrationDate = DateTime.Now;
                objUser.FirstName = objUserModel.FirstName;
                objUser.LastName = objUserModel.LastName;
                objUser.Username = objUserModel.Username;
                objUser.Password = objUserModel.Password;
                objUser.Email = objUserModel.Email;
                objUser.Address = objUserModel.Address;
                objUser.PhoneNumber = objUserModel.PhoneNumber;
                objUser.UserType = objUserModel.UserType;
                objSnapDBEntities.Users.Add(objUser);
                objSnapDBEntities.SaveChanges();
                objUserModel.successMessage = "Successfully registered";
                return View("Login");
            }
            return View();
        }
        //void connectionString()
        //{
        //    conn.ConnectionString = "Server=DESKTOP-0ERD31D\\SQLEXPRESS;Database=SnapDrive;Trusted_Connection=True;";
        //}
        public ActionResult Login()
        {
            LoginModel objLoginModel = new LoginModel();
            return View(objLoginModel);
        }
        [HttpPost]
        public ActionResult Login(LoginModel objLoginModel)
        {
            if (ModelState.IsValid)
            {
                if (objSnapDBEntities.Users.Where(u => u.Username == objLoginModel.Username && u.Password == objLoginModel.Password).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Email and Password does not match");
                    return View();
                }
                else
                {
                    Session["Username"] = objLoginModel.Username;
                   return RedirectToAction("Index");
                }
            }
            return View(objLoginModel);
            //connectionString();
            //conn.Open();
            //com.Connection = conn;
            //com.CommandText = "Select * from Users where Username='"+objLoginModel.Username+"' and Password= '"+objLoginModel.Password+"'";
            //dr = com.ExecuteReader();
            //if(dr.Read())
            //{
            //    conn.Close();
            //    return View("UserDesh");
            //}
            //else
            //{
            //    conn.Close();
            //    return View("Login");
            //}
        }
    }
}