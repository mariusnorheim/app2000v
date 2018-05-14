using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class CookieController : Controller
    {
        // Get cookie
        public string Get()
        {
            return Request.Cookies["UserID"];
        }

        // Set cookie
        public void Set(UserModel model)
        {
            string userid = model.UserID;

            Response.Cookies.Append("UserID", userid);
        }

        // Remove cookie
        public void Remove()
        {
            Response.Cookies.Delete("UserID");
        }
    }
}