using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Faculty
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int FacultyId { get; set; }


		[Required(ErrorMessage = "Faculty Name cannot be Empty")]
		[Display(Name = "Faculty Name")]
		public string Name { get; set; }


		public int? StudentId { get; set; }
		public Student Student { get; set; }

	}
}
