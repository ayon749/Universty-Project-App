using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityProject.Models;

namespace UniversityProject.Controllers
{
    public class ClassroomsController : Controller
    {
		private ProjectDbContext db = new ProjectDbContext();

		// GET: Classrooms
		public ActionResult Index()
        {
            return View();
        }
		public ActionResult AllocateClassRoom()
		{
			ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
			ViewBag.ClassRoomId = new SelectList(db.ClassRooms, "ClassRoomId", "RoomNo");

			return View();

		}
		public JsonResult GetCourseByDeptId(int deptId)
		{
			var courses = db.Courses.Where(x => x.DepartmentId == deptId).ToList();
			return Json(courses);
		}
    }
}