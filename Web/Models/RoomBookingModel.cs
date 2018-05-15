using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class RoomBookingModel 
    {
        public int RoomID { get; set; }

        public enum Room
        {
            [Display(Name = "Single Room")]
            Single = 1,
            [Display(Name = "Double Room")]
            Double,
            [Display(Name = "Family Suite")]
            Family,
            [Display(Name = "Family Deluxe")]
            Deluxe,
            [Display(Name = "Executive Suite")]
            Executive,
            [Display(Name = "Conference Room")]
            Conference
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Arrival")]
        public DateTime DateFrom { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Departure")]
        public DateTime DateTo { get; set; }

        [Required]
        public int Roomtype { get; set; }
    }
}
