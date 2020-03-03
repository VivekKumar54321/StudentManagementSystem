using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Registration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RegId { get; set; }



        public Student Student { get; set; }
        public int StudentId { get; set; }


        public Billing Billing { get; set; }
        public int BillingId { get; set; }


        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }


        [Required(ErrorMessage = "Enter the  IssuedDate ")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime IssuedDate { get; set; }


    }
}
