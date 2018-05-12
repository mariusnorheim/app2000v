using System.ComponentModel.DataAnnotations;

namespace Web.Data
{
    public class RoomBooking
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "DateFrom")]
        public string DateFrom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "DateTo")]
        public string DateTo { get; set; }

        [Required]
        [Display(Name = "Roomtype")]
        public string Roomtype { get; set; }
    }
}