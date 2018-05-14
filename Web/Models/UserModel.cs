using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class UserModel
    {
        public string UserID { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(80)]
        public string Email { get; set; }

        [Required]
        [StringLength(120)]
        public string Password { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "First name")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(45)]
        public string City { get; set; }

        [Required]
        [StringLength(10)]
        public string Postcode { get; set; }

        [StringLength(20)]
        public string Telephone { get; set; }
    }
}
