using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Web.Models
{
    public class BookingModel
    {
        public RoomBookingModel RoomBooking { get; set; }
        public HallBookingModel HallBooking { get; set; }
    }
}