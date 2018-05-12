using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Web.Data;
using Web.Models;
using Web.Utils;
using MySql.Data.MySqlClient;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private LoginModel model;

        public LoginController(LoginModel model)
        {
            this.model = model;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            WebDbContext db = HttpContext.RequestServices.GetService(typeof(Web.Models.WebDbContext)) as WebDbContext;
            Boolean validLogin = false;
            string uid = this.model.Email;
            string upw = this.model.Password;

            // Fetch salt for user
            MySqlDataReader getValues = db.GetLoginData(uid);
            if(getValues.Read())
            {
                string salt = getValues.GetString(0);

                // Hash password with salt
                PasswordHasher pwHasher = new PasswordHasher();
                HashResult hashedPassword = pwHasher.HashStoredSalt(upw, salt, SHA512.Create());

                if(db.GetLoginMatch(uid, hashedPassword.Digest) == 1) { validLogin = true; }

                // Check for login match
                if(validLogin)
                {
                    // TODO: Save user information in cookies

                    return RedirectToAction("LoggedIn");
                }
            }

            getValues.Dispose();
            return RedirectToPage("/Login");
        }

        public IActionResult LoggedIn()
        {
            // TODO: Set ID from cookie
            var viewModel = new LoggedInViewModel { ID = 1 };
            return View(viewModel);
        }

        /*
        public async Task<IActionResult> OnPostAsync()
        {
            _db.Users.Add(User);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
        */
    }
}