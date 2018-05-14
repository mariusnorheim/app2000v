using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Utils;
using MySql.Data.MySqlClient;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            // Read user information cookie
            //string userid = Request.Cookies["UserID"];
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            WebDbContext db = HttpContext.RequestServices.GetService(typeof(Web.Models.WebDbContext)) as WebDbContext;
            Boolean validLogin = false;
            var email = model.Email;
            var password = model.Password;
            var userid = "";
            var salt = "";

            // Validate input
            if(!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                // Fetch salt for user
                MySqlDataReader getValues = db.GetLoginData(email);
                if(getValues.Read())
                {
                    userid = getValues.GetString(0);
                    salt = getValues.GetString(1);
                }

                getValues.Dispose();

                // Hash password with salt
                PasswordHasher pwHasher = new PasswordHasher();
                HashResult hashedPassword = pwHasher.HashStoredSalt(password, salt, SHA512.Create());

                // Check for login match
                if(db.GetLoginMatch(email, hashedPassword.Digest) == 1) { validLogin = true; }

                if(validLogin)
                {
                    // Save user information in cookie
                    //CookieModel cookieModel = new CookieModel { UserID = userid };
                    //CookieController c = new CookieController();
                    //c.Set(cookieModel);

                    //return RedirectToRoute("");
                }
                else
                {
                    return RedirectToAction("LoginFailedView");
                }
            }

            return RedirectToAction("EmptyFieldsView");
        }

        // View for failed login
        public IActionResult LoginFailedView()
        {
            return View();
        }

        // View for missing input fields
        public IActionResult EmptyFieldsView()
        {
            return View();
        }

        // View for error handling
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}