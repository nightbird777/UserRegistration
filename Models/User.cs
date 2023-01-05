using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Models
{
    public class User
    {
        [Required(ErrorMessage = "Enter First Name: ")]
        [Display(Name = "Enter First Name: ")]
        [StringLength(maximumLength:15, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 15 character long!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Last Name: ")]
        [Display(Name = "Enter Last Name: ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Upload Profile Photos: ")]
        [Display(Name = "Profile Picture: ")]
        public string Image { get; set; }
    }
}