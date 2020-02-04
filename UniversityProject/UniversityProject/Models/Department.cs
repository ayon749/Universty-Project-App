using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityProject.Models
{
	public class Department
	{
		[Key]
		public int DepartmentId { get; set; }
		[Display(Name ="Code")]
		[Required(ErrorMessage ="Please enter the code")]
		[StringLength(7,MinimumLength =2,ErrorMessage ="Code must be between 2 to 7 characters")]
		[Remote("IsCodeExits", "Departments",HttpMethod ="POST",ErrorMessage ="Code already exist.")]
		public string DepartmentCode { get; set; }

		[Display(Name ="Name")]
		[Required(ErrorMessage = "Please enter the name")]
		[Remote("IsNameExits", "Departments", HttpMethod = "POST", ErrorMessage = "Name already exist.")]
		public string DepartmentName { get; set; }
	}
}