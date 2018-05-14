using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class HallBookingModel
    {
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }
        public int Halltype { get; set; }
    }
}
