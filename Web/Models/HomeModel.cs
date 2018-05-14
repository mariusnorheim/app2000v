using Microsoft.AspNetCore.Mvc;

namespace Web.Models
{
    public class HomeModel
    {
        [BindProperty]
        public RoomBookingModel RoomBooking { get; set; }
        public HallBookingModel HallBooking { get; set; }

        public void OnGet()
        {

        }
    }
}
