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
        public IActionResult AvailableRooms([Bind] RoomBookingModel booking)
        {
            WebDbContext db = HttpContext.RequestServices.GetService(typeof(Web.Utils.WebDbContext)) as WebDbContext;
            var guestid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(booking.DateFrom > booking.DateTo)
            {
                return View("RegisterRoomBookingModelFailed", booking);
            }

            if(ModelState.IsValid)
            {
                // Return list of available rooms
                booking.AvailableRooms = db.GetAvailableRooms(booking);

                // Select first item in list and make reservation
                var viewModel = new RoomModel();
                //viewModel = booking.AvailableRooms.First();
                viewModel.RoomID = Convert.ToInt32(guestid);
                return View("RegisterRoomBooking", viewModel);
            }

            return View("Index", booking);
        }

        [HttpGet]
        // View for registration model invalid
        public IActionResult RegisterRoomBooking(RoomModel room)
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