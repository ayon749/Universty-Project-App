using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityProject.Models;

namespace UniversityProject.Controllers
{
	public class CoursesController : Controller
	{
		private ProjectDbContext db = new ProjectDbContext();

		// GET: Courses
		public ActionResult Index()
		{
			var courses = db.Courses.Include(c => c.Department).Include(c => c.Semester);
			return View(courses.ToList());
		}

		// GET: Courses/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Course course = db.Courses.Find(id);
			if (course == null)
			{
				return HttpNotFound();
			}
			return View(course);
		}

		// GET: Courses/Create
		public ActionResult Create()
		{
			ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
			ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName");
			return View();
		}

		// POST: Courses/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "CourseId,CourseCode,CourseName,Credit,Description,DepartmentId,SemesterId")] Course course)
		{
			if (ModelState.IsValid)
			{
				db.Courses.Add(course);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", course.DepartmentId);
			ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName", course.SemesterId);
			return View(course);
		}

		// GET: Courses/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Course course = db.Courses.Find(id);
			if (course == null)
			{
				return HttpNotFound();
			}
			ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", course.DepartmentId);
			ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName", course.SemesterId);
			return View(course);
		}

		// POST: Courses/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "CourseId,CourseCode,CourseName,Credit,Description,DepartmentId,SemesterId")] Course course)
		{
			if (ModelState.IsValid)
			{
				db.Entry(course).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", course.DepartmentId);
			ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName", course.SemesterId);
			return View(course);
		}

		// GET: Courses/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Course course = db.Courses.Find(id);
			if (course == null)
			{
				return HttpNotFound();
			}
			return View(course);
		}

		// POST: Courses/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Course course = db.Courses.Find(id);
			db.Courses.Remove(course);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
		public JsonResult CoursesByDept(int departId)
		{
			var courses = db.Courses.Where(x => x.DepartmentId == departId).ToList();
			return Json(courses);
		}
		public JsonResult CourseNamebyId(int courseId)
		{
			var course = db.Courses.FirstOrDefault(x => x.CourseId == courseId);
			return Json(course);
		}


		public ActionResult ViewCourseStatictis ()
		{
			ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");

			return View();

		}
		public JsonResult CourseInfoByDeptId(int id)
		{
			var course = db.Courses.Where(x => x.DepartmentId == id).ToList();
			List<CourseInfo> courses = new List<CourseInfo>();
			foreach(var aCourse in course)
			{
				CourseInfo courseInfo = new CourseInfo();
				courseInfo.CourseCode = aCourse.CourseCode;
				courseInfo.CourseName = aCourse.CourseName;
				var sem = db.Semesters.FirstOrDefault(x => x.SemesterId == aCourse.SemesterId);
				courseInfo.SemesterName = sem.SemesterName;
				var assignedToInfo = db.AssignedCourses.FirstOrDefault(x => x.CourseId == aCourse.CourseId);
				if(assignedToInfo!=null)
				{
					Teacher assignedTo = db.Teachers.FirstOrDefault(x => x.TeacherId == assignedToInfo.TeacherId);
					courseInfo.AssignedTo = assignedTo.TeacherName;
				}
				else
				{
					courseInfo.AssignedTo = "Not Assigned Yet";
				}
				courses.Add(courseInfo);

			}
			return Json(courses);
		}
	}
}
