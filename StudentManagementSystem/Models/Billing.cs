using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Models
{

	//public class BaseEntity
	//{
	//	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	//	[Key]
	//	public int Id { get; set; }
	//}

	public class Billing 
	{


		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int BillingId { get; set; }


		[Required(ErrorMessage = "Enter the Billing Type")]
		[Display(Name = "Billing Type")]
		public string Type { get; set; }



		[Required(ErrorMessage = "Enter the Billing Date")]
		[Display(Name = "Billing Date")]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime Date { get; set; }


		[Required(ErrorMessage = "Enter the Billing Amount")]
		[Display(Name = "Billing Amount")]
		public double Amount { get; set; }
		
		public int? StudentId { get; set; }
		public Student Student { get; set; }

	}
}
