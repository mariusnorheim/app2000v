using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly WebDbContext _db;
        [BindProperty]
        public UserData User { get; set; }

        public RegisterController(WebDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            return RedirectToAction("OnPostAsync");
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