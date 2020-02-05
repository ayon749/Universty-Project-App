using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityProject.Models
{
	public class Teacher
	{
		[Key]
		public int TeacherId { get; set; }
		[Display(Name ="Name")]
		public string TeacherName { get; set; }
		public string Address { get; set; }
		[Required(ErrorMessage ="Please enter email address.")]
		[EmailAddress(ErrorMessage ="Invalid email address")]
		[Remote("IsEmailExisit","Teachers",ErrorMessage ="Email already exist.")]
		public string Email { get; set; }
		[Display(Name ="Contact No")]
		public double ContactNo { get; set; }
		public int DesignationId { get; set; }
		[ForeignKey("DesignationId")]
		public virtual Designation Designation { get; set; }
		public int DepartmentId { get; set; }
		[ForeignKey("DepartmentId")]
		public virtual Department Department { get; set; }
		[Range(0,100,ErrorMessage ="Credit can not be negative number.")]
		public double CreditToBeTaken { get; set; }

		public double RemainingCredit { get; set; }
	}
}