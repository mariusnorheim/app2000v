using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class HallBookingModel
    {
        public int HallID { get; set; }

        public enum Hall
        {
            [Display(Name = "Banquet Hall")]
            Banquet = 1,
            Stage,
            [Display(Name = "Outside Garden Area")]
            Garden,
            [Display(Name = "Outside Pool Area")]
            Pool
        }

        [DataType(DataType.DateTime)]
        [Display(Name = "Arrival")]
        public DateTime DateFrom { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Departure")]
        public DateTime DateTo { get; set; }

        public int Halltype { get; set; }
    }
}
