using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Utils;
using MySql.Data.MySqlClient;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // View for registration form
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        // Post action for registration form
        [HttpPost]
        public IActionResult RegisterUser([Bind] UserModel user)
        {
            WebDbContext db = HttpContext.RequestServices.GetService(typeof(Web.Utils.WebDbContext)) as WebDbContext;

            if(ModelState.IsValid)
            {
                // Check if email already exists in db
                if(db.GetLoginUsername(user) > 0)
                {
                    return RedirectToAction("RegisterUserExists");
                }

                // Generate new salt and hash password
                var password = user.Password.ToString();
                PasswordHasher pwHasher = new PasswordHasher();
                HashResult hashedPassword = pwHasher.HashNewSalt(password, 20, SHA512.Create());
                user.Salt = hashedPassword.Salt;
                user.Password = hashedPassword.Digest;

                // Register new user
                db.RegisterUser(user);

                // Redirect to user area
                ModelState.Clear();
                return RedirectToAction("UserLogin");
            }

            // Model data invalid
            return RedirectToAction("RegisterModelFailed");
        }

        // View for registration model invalid
        [HttpGet]
        public IActionResult RegisterUserExists()
        {
            return View();
        }

        // View for registration model fail
        [HttpGet]
        public IActionResult RegisterModelFailed()
        {
            return View();
        }

        // View for login form
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }

        // Post action for login form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin([Bind] UserModel user)
        {
            WebDbContext db = HttpContext.RequestServices.GetService(typeof(Web.Utils.WebDbContext)) as WebDbContext;

            ModelState.Remove("Firstname");
            ModelState.Remove("Lastname");
            ModelState.Remove("Address");
            ModelState.Remove("City");
            ModelState.Remove("Postcode");
            ModelState.Remove("Telephone");

            if(ModelState.IsValid)
            {
                // Set empty variables incase invalid user
                user.Salt = "";
                // Fetch salt for user
                MySqlDataReader getValues = db.GetLoginData(user);
                if(getValues.Read())
                {
                    user.UserID = getValues.GetString(0);
                    user.Salt = getValues.GetString(1);
                }

                getValues.Dispose();

                // Hash password with salt
                var salt = user.Salt.ToString();
                var password = user.Password.ToString();
                PasswordHasher pwHasher = new PasswordHasher();
                HashResult hashedPassword = pwHasher.HashStoredSalt(password, salt, SHA512.Create());
                user.Password = hashedPassword.Digest;

                int LoginStatus = db.LoginValidate(user);
                // Login success
                if(LoginStatus > 0)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserID)
                    };

                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "User");
                }

                // Login fail
                else
                {
                    return RedirectToAction("UserLoginFailed");
                }
            }

            // Model data invalid
            return RedirectToAction("UserModelFailed");
        }

        // View for login fail
        [HttpGet]
        public IActionResult UserLoginFailed()
        {
            return View();
        }

        // View for login model invalid
        [HttpGet]
        public IActionResult UserModelFailed()
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