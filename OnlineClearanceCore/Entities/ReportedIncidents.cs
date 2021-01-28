using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EdoTrafficMgtCore.Core.Entities
{
	[NotMapped]
	public class ReportedIncidents
    { 
		[Key]
		public int Id { get; set; }
		public string Incident { get; set; }
		public string IncidentCode { get; set; }
        public string FirstName { get; set; }
		public string OtherNames { get; set; }
		public string Address { get; set; }
		public string IncidentDate { get; set; }
		public string ReportedBy { get; set; }
		public string IncidentType { get; set; }
		public string IncidentLocation { get; set; }
		public string Photo1 { get; set; }
		public string Photo2 { get; set; }
		public string lga { get; set; }
		public string state { get; set; }
		public string email { get; set; }
		public string box { get; set; }
		public string tel { get; set; }
		public string AnyotherInfo { get; set; }
		public string NearestBusStop { get; set; }
		public string town { get; set; }
		public bool decision { get; set; }
		public string remarks { get; set; }
		public DateTime datecreated { get; set; }
		public string createdby { get; set; }
	}
}
