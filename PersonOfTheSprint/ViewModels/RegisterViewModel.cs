using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonOfTheSprint.Models;

namespace PersonOfTheSprint.ViewModels
{
    public class RegisterViewModel
    {
        public virtual TeamMember TeamMember { get; set; }

        [Required (ErrorMessage = "An email address is required to register.")]
        [DataType(DataType.EmailAddress)]
        [Remote("CheckEmailAvailability", "Register", HttpMethod = "POST", ErrorMessage = "This email address already exists for another user.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Your first name is required to register.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Your Last name is required to register.")]
        public string LastName { get; set; }

        public int NumberOfTimesWon { get; set; }
    }
}