using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Validations.Validators;

namespace Validations.Models
{
    public class UserDetails
    {
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [NotEqualTo("FirstName", ErrorMessage ="Last name can not be same as first name!")]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string BirthMonth { get; set; }

        public long PhoneNum { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EqualTo("Password", ErrorMessage = "Password does not match Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}