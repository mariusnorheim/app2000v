using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [StringLength(80)]
        public string Email { get; set; }

        [Required]
        [StringLength(120)]
        public string Password { get; set; }
    }
}