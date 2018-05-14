using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Utils
{
    public class Cookie
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Cookie(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        // Get cookie
        public string Get()
        {
            return _httpContextAccessor.HttpContext.Request.Cookies["UserID"];
        }

        // Set cookie
        public void Set(UserModel model)
        {
            string userid = model.UserID;

            _httpContextAccessor.HttpContext.Response.Cookies.Append("UserID", userid);
        }

        // Remove cookie
        public void Remove()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("UserID");
        }
    }
}
