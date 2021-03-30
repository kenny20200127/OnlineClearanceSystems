using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineClearanceCore.Core.Entities
{
	[NotMapped]
	public class Student
    { 
		[Key]
		public int Id { get; set; }
		public string StudentId { get; set; }
        public string FirstName { get; set; }
		public string OtherNames { get; set; }
		public DateTime DOB { get; set; }
		public string Address { get; set; }
		public string College { get; set; }
		public string Campus { get; set; }
		public string department { get; set; }
		public string CourseProgram { get; set; }
		public string Photo { get; set; }
		public string lga { get; set; }
		public string state { get; set; }
		public string email { get; set; }
		public string tel { get; set; }
		public string remarks { get; set; }
        public DateTime GraduatedDate { get; set; }
        public string GPA { get; set; }
        public DateTime ApprovedDate { get; set; }
		public DateTime ApplicationDate { get; set; }
		public string ApprovedBy { get; set; }
		public string Status { get; set; }

		public DateTime datecreated { get; set; }
		public string createdby { get; set; }
	}
}
