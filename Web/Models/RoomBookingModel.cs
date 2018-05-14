using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class RoomBookingModel
    {
        [DataType(DataType.Date)]
        [Display(Name = "DateFrom")]
        public DateTime DateFrom { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "DateTo")]
        public DateTime DateTo { get; set; }

        [Display(Name = "Roomtype")]
        public int Roomtype { get; set; }
    }
}
