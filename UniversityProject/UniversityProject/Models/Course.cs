using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityProject.Models
{
	public class Course
	{
		[Key]
		public int CourseId { get; set; }
		[StringLength(50,MinimumLength =5,ErrorMessage ="Code must be at least 5 character in length.")]
		public string CourseCode { get; set; }
		public string CourseName { get; set; }
		[Range(0.5,5,ErrorMessage ="`credit range is in between 0.5 to 5.")]
		public double Credit { get; set; }
		public string Description { get; set; }
		public int DepartmentId { get; set; }
		[ForeignKey("DepartmentId")]
		public virtual Department Department { get; set; }
		public int SemesterId { get; set; }
		[ForeignKey("SemesterId")]
		public virtual Semester Semester { get; set; }
	}
}