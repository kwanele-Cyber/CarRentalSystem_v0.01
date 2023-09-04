using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRentalSystem.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Username is Required")]
        [MinLength(6)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(7)]
        [DataType(DataType.Password)] 
        public string Password { get; set; }
    }
}