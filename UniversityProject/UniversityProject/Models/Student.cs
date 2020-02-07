using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityProject.Models
{
	public class Student
	{
		[Key]
		public int StudentId { get; set; }
		[Display(Name ="Name")]
		public string StudentName { get; set; }
		public string RegistrationNo { get; set; }
		[Required(ErrorMessage = "Please enter email address.")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		public string Email { get; set; }
		[Display(Name ="Contact No.")]
		public string ContactNo { get; set; }
		[Display(Name ="Date")]
		public DateTime RegistrationDate { get; set; }
		public string Address { get; set; }
		public int DepartmentId { get; set; }
		[ForeignKey("DepartmentId")]
		public virtual Department Department { get; set; }
	}
}