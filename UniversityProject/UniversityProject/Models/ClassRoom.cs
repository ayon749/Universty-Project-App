using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityProject.Models
{
	public class ClassRoom
	{
		[Key]
		public int ClassRoomId { get; set; }
		public int RoomNo { get; set; }
	}
}