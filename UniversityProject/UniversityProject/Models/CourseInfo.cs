using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityProject.Models
{
	public class CourseInfo
	{
		public string  CourseCode { get; set; }
		public string CourseName { get; set; }
		public string SemesterName { get; set; }
		public string AssignedTo { get; set; }
	}
}