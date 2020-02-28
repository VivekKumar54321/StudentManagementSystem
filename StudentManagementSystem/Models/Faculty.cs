using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Faculty
    {
		public int Id { get; set; }
		
		
		[Required(ErrorMessage = "Faculty Name cannot be Empty")]
		[Display(Name = "Faculty Name")]
		public string Name { get; set; }


	

	}
}
