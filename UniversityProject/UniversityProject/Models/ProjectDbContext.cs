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
	}
}