using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRentalSystem.Models
{
    public class UserModel
    {
        [Required]
        public int UserID { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Username is required")]
        [MinLength(6)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        [MinLength(7)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must confirm Password!")]
        [MinLength(7)]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password" , ErrorMessage ="Passwords must match!!")]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Firstname is required!")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname is required")]
        [DisplayName("Surname")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number is required")]
        [DisplayName("Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Adress is required")]
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime RegistrationDate { get; set; }

        public string successMessage { get; set; }
        public string UserType {  get; set; }   


    }
}