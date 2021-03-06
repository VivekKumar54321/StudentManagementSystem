﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Student 
    {
        	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        	[Key]
        public int StudentId { get; set; }


        [Required(ErrorMessage = "Enter the  FirstName ")]
        [DataType(DataType.Text)]
        [Display(Name = "FirstName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the  FatherName ")]
        [DataType(DataType.Text)]
        [Display(Name = "FatherName")]
         public string FatherName { get; set; }

        [Required(ErrorMessage = "Select the  Gender ")]
        [DataType(DataType.Text)]
        [Display(Name = "Gender")]
        public string Gender { get; set; }



        [Required(ErrorMessage = "Enter the  Address ")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter the  EmailAddress ")]
        [Display(Name = "EmailAddress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



        [Required(ErrorMessage = "Enter the  PhoneNo ")]
        [Display(Name = "PhoneNo")]
        public int? PhoneNo { get; set; }

        

        [Required(ErrorMessage = "Enter the  DOB ")]
        [Display(Name = "DateofBirth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DOB { get; set; }


        //[Required(ErrorMessage = "Enter the  IssuedDate ")]
     
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //public DateTime IssuedDate { get; set; }

         


    }
}
