using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Utils;

namespace Web.Controllers
{
    //[Authorize]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("UserLogin", "Login");
        }

        // Search available rooms
        [HttpPost]
        public async Task<IActionResult> AvailableRooms([Bind] RoomBookingModel booking)
        {
            WebDbContext db = HttpContext.RequestServices.GetService(typeof(Web.Utils.WebDbContext)) as WebDbContext;

            ModelState.Remove("Room");

            if(ModelState.IsValid)
            {
                // Return available rooms
                List<RoomModel> roomList = db.GetAvailableRooms(booking);
                return View(db.GetAvailableRooms(booking));
            }

            // Model data invalid
            return View();
        }

        [HttpGet]
        // View for registration model invalid
        public IActionResult RegisterRoomBooking()
        {
            return View(); 
        }

        [HttpGet]
        // View for registration model fail
        public IActionResult RegisterRoomBookingModelFailed()
        {
            return View();
        }
    }
}