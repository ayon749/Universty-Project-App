using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityProject.Models;

namespace UniversityProject.Controllers
{
    public class StudentsController : Controller
    {
		private ProjectDbContext db = new ProjectDbContext();
		// GET: Students
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Register()
		{

			ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
			return View();
		}

		[HttpPost]
		public ActionResult Register([Bind(Include = "StudentName,Email, ContactNo, RegistrationDate, Address,DepartmentId")]Student student)
		{
			if (ModelState.IsValid)
			{
				var year = student.RegistrationDate.Year;
				var students = db.Students.ToList();
				var studentCount = students.Count();
				int serial = studentCount + 1;
				var departments = db.Departments.FirstOrDefault(x => x.DepartmentId == student.DepartmentId);
				student.RegistrationNo=departments.DepartmentCode+"-"+year+"-"+ serial.ToString().PadLeft(3, '0');
				db.Students.Add(student);
				db.SaveChanges();
				
			}

				ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
			return View();
		}
	}
}