using Microsoft.AspNetCore.Mvc;
using Web.Data;

namespace Web.Models
{
    public class RegisterModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public int Telephone { get; set; }
    }
}
