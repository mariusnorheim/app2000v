using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        [HttpGet]
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
        public IActionResult AvailableRooms(RoomBookingModel booking)
        {
            WebDbContext db = HttpContext.RequestServices.GetService(typeof(Web.Utils.WebDbContext)) as WebDbContext;
            var today = DateTime.Now;
            if(booking.DateFrom > booking.DateTo || booking.DateFrom < today.AddDays(-1))
            {
                return View("RegisterRoomBookingModelFailed", booking);
            }

            if(ModelState.IsValid)
            {
                // Return list of available rooms and convert to int values
                booking.AvailableRooms = db.GetAvailableRooms(booking);
                //List<int> roomlist = booking.AvailableRooms.ConvertAll<int>(Converter<RoomModel, int.Parse>);

                // Select first item in list and make reservation
                booking = booking.AvailableRooms.First();
                return RedirectToAction("RegisterRoomBooking", booking);
            }

            return View("Index", booking);
        }

        [HttpPost]
        // View for registration success
        public IActionResult RegisterRoomBooking([Bind] RoomBookingModel booking)
        {
            WebDbContext db = HttpContext.RequestServices.GetService(typeof(Web.Utils.WebDbContext)) as WebDbContext;
            var guestid = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.Name));

            ModelState.Remove("AvailableRooms");
            ModelState.Remove("Room");

            if(ModelState.IsValid)
            {
                // Register new room booking
                db.RegisterBooking(guestid, booking);

                // Redirect to user area
                ModelState.Clear();
                return View();
            }

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