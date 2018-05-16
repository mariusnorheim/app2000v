using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class RoomBookingModel 
    {
        public int RoomID { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Arrival")]
        public DateTime DateFrom { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Departure")]
        public DateTime DateTo { get; set; }

        [Required]
        [EnumDataType(typeof(Room))]
        public Room Roomtype { get; set; }

        public string Remark { get; set; }

        public List<RoomBookingModel> AvailableRooms { get; set; }

        public enum Room
        {
            [Display(Name = "Single Room")]
            SingleRoom = 1,
            [Display(Name = "Double Room")]
            DoubleRoom = 2,
            [Display(Name = "Family Suite")]
            FamilySuite = 3,
            [Display(Name = "Family Deluxe")]
            FamilyDeluxe = 4,
            [Display(Name = "Executive Suite")]
            ExecutiveSuite = 5,
            [Display(Name = "Conference Room")]
            ConferenceRoom = 6
        }
    }
}
