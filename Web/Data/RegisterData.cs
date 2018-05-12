using System.ComponentModel.DataAnnotations;

namespace Web.Data
{
    public class RegisterData
    {
        [Required]
        [StringLength(40, ErrorMessage = "Firstname length can not exceed 40 characters.")]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Lastname length can not exceed 40 characters.")]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "Email length can not exceed 80 characters.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(120, ErrorMessage = "Password length can not exceed 120 characters.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Address length can not exceed 100 characters.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "City length can not exceed 45 characters.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Postcode length can not exceed 10 characters.")]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        [StringLength(20, ErrorMessage = "Telephone length can not exceed 20 characters.")]
        [Display(Name = "Telephone")]
        public string Telephone { get; set; }
    }
}
