using Microsoft.AspNetCore.Mvc;
using Web.Data;

namespace Web.Models
{
    public class LoginModel
    {
        [BindProperty]
        public UserData User { get; set; }
        public string Email{ get; set; }
        public string Password { get; set; }
    }
}