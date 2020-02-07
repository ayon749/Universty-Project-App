using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityProject.Models
{
	public class Student
	{
		[Key]
		public int StudentId { get; set; }
		public string StudentName { get; set; }
		public string RegistrationNo { get; set; }
		[Required(ErrorMessage = "Please enter email address.")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		public string Email { get; set; }
		public string ContactNo { get; set; }
		public DateTime RegistrationDate { get; set; }
		public string Address { get; set; }
		public int DepartmentId { get; set; }
	}
}