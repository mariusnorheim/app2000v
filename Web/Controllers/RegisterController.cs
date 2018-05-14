using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Utils;

namespace Web.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            WebDbContext db = HttpContext.RequestServices.GetService(typeof(Web.Utils.WebDbContext)) as WebDbContext;
            Boolean existingid = false;
            var email = model.Email;
            var password = model.Password;
            var firstname = model.Firstname;
            var lastname = model.Lastname;
            var address = model.Address;
            var city = model.City;
            var postcode = model.Postcode;
            var telephone = model.Telephone;

            // Validate input
            if(!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(firstname)
                && !string.IsNullOrWhiteSpace(lastname) && !string.IsNullOrWhiteSpace(address) && !string.IsNullOrWhiteSpace(city)
                && !string.IsNullOrWhiteSpace(postcode))
            {
                // Check if email already exists in db
                if(db.GetLoginUsername(email) > 0) { existingid = true; }
                if(existingid) { return RedirectToAction("UsernameExistsView"); }

                // Execute save
                if(!existingid)
                {
                    // Generate new salt and hash password
                    PasswordHasher pwHasher = new PasswordHasher();
                    HashResult hashedPassword = pwHasher.HashNewSalt(password, 20, SHA512.Create());
                    var salt = hashedPassword.Salt;
                    var passwordHash = hashedPassword.Digest;

                    db.UserAdd(email, passwordHash, salt, firstname, lastname, address, city, postcode, telephone);

                    // Redirect new user to login
                    var userModel = new UserModel
                    {
                        Email = email,
                        Password = passwordHash
                    };

                    return View(userModel);
                }
            }

            return RedirectToAction("EmptyFieldsView");
        }

        // View for existing email in database
        public IActionResult UsernameExistsView()
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