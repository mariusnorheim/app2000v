using Microsoft.AspNetCore.Mvc;
using Web.Data;

namespace Web.Models
{
    public class HomeModel
    {
        [BindProperty]
        public RoomBookingData RoomBooking { get; set; }
        public HallBookingData HallBooking { get; set; }

        public void OnGet()
        {

        }
    }
}
