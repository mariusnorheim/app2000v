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
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
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
                    // TODO: Save user information in cookies

                    return RedirectToAction("LoggedInView");
                }
                else
                {
                    return RedirectToAction("NotLoggedInView");
                }
            }

            return RedirectToAction("EmptyFieldsView");
        }

        // View for successful login
        public IActionResult LoggedInView()
        {
            // TODO: Set ID from cookie
            var viewModel = new LoggedInViewModel { ID = 1 };
            return View(viewModel);
        }

        // View for failed login
        public IActionResult NotLoggedInView()
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