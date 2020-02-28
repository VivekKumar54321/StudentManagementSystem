using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Billing
    {
		public int Id { get; set; }



		[Required(ErrorMessage = "Enter the Billing Type")]
		[Display(Name = "Billing Type")]
		public string Type { get; set; }
		[Required(ErrorMessage = "Enter the Billing Date")]
		[Display(Name = "Billing Date")]
		public DateTime Date { get; set; }
		[Required(ErrorMessage = "Enter the Billing Amount")]
		[Display(Name = "Billing Amount")]
		public double Amount { get; set; }



	
	}
}
