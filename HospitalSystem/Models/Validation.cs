using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalSystem.Models
{
    public class Validation
    {
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Required(ErrorMessage = "please enter a valid username")]
        public string Email { get; set; }


        [Required(ErrorMessage = "please enter a password")]
        [StringLength(100, ErrorMessage = "The{0} must be at least {2} characters long.", MinimumLength = 10)]
        public string Password { get; set; }
    }
}