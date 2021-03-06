﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversityProject.Models
{
	public class ProjectDbContext: DbContext
	{
		public DbSet<Department> Departments { get; set; }
		public DbSet<Semester> Semesters { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Designation> Designations { get; set; }
		public DbSet<AssignedCourses>AssignedCourses { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<ClassRoom> ClassRooms { get; set; }
	}
}