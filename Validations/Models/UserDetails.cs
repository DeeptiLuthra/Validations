using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validations.Validators;

namespace Validations.Models
{
    public class UserDetails
    {
        public int ID { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        [NotEqualTo("FirstName", ErrorMessage ="Last name can not be same as first name!")]
        public string LastName { get; set; }

        [Range(18, 60, ErrorMessage="Age must be over 18 and under 60")]
        public int Age { get; set; }

        [Display(Name ="Birth Month")]
        public string BirthMonth { get; set; }

        public static IEnumerable<SelectListItem> Months
        {
            get
            {
                return DateTimeFormatInfo
                       .InvariantInfo
                       .MonthNames
                       .Where(m=> !string.IsNullOrEmpty(m))
                       .Select((monthName, index) => new SelectListItem
                       {
                           Value = (index + 1).ToString(),
                           Text = monthName
                       });
            }
        }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression("\\d{9}",ErrorMessage ="Please enter a 9-digit number without spaces")]
        [Display(Name ="Phone Number")]
        public long PhoneNum { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage ="Not a valid e-mail address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(Int32.MaxValue, MinimumLength = 8,ErrorMessage ="Password must be mminimum {2} characters long")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage ="Must match Password")]
        //[EqualTo("Password", ErrorMessage = "Password does not match Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}