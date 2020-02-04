using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityProject.Models
{
	public class Department
	{
		[Key]
		public int DepartmentId { get; set; }
		[Required(ErrorMessage ="Please enter the code")]
		[StringLength(7,MinimumLength =2,ErrorMessage ="Code must be between 2 to 7 characters")]
		public string DepartmentCode { get; set; }
		[Required(ErrorMessage = "Please enter the name")]
		public string DepartmentName { get; set; }
	}
}