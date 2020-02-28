using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Enter the  UserName ")]
        [Display(Name = "Username")]
        public string UserName { get; set; }



        [Required(ErrorMessage = "Enter the  Password ")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
