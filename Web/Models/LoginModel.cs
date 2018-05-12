﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Web.Data;

namespace Web.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(80, ErrorMessage = "Email length can not exceed 80 characters.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(120, ErrorMessage = "Password length can not exceed 120 characters.")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}