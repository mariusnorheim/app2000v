﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Data;
using Web.Models;
using Web.Utils;
using MySql.Data.MySqlClient;

namespace Web.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            WebDbContext db = HttpContext.RequestServices.GetService(typeof(Web.Models.WebDbContext)) as WebDbContext;

            var email = model.Email;
            var pw = model.Password;

            // Fetch salt for user
            MySqlDataReader getValues = db.GetLoginData(email);
            if(getValues.Read())
            {
                var userid = getValues.GetString(0);
                var salt = getValues.GetString(1);

                // Hash password with salt
                PasswordHasher pwHasher = new PasswordHasher();
                HashResult hashedPassword = pwHasher.HashStoredSalt(email, salt, SHA512.Create());

                if(db.GetLoginMatch(email, hashedPassword.Digest) == 1)
                { validLogin = true; }

                // Check for login match
                if(validLogin)
                {
                    // TODO: Save user information in cookies

                    return RedirectToAction("LoggedIn");
                }
            }

            getValues.Dispose();
            return RedirectToAction("NotLoggedIn");
        }

        public IActionResult LoggedIn()
        {
            // TODO: Set ID from cookie
            var viewModel = new LoggedInViewModel { ID = 1 };
            return View(viewModel);
        }
    }
}