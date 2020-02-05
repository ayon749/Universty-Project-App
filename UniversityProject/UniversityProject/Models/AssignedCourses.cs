using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityProject.Models
{
	public class AssignedCourses
	{
		[Key]
		public int AssignedCourseId { get; set; }
		public int CourseId { get; set; }
		[ForeignKey("CourseId")]
		public virtual Course Course { get; set; }
		public int TeacherId { get; set; }
		
	}
}