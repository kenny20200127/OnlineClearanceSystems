using EdoTrafficMgtCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdoTrafficMgtCore.Models
{
    public class IncidentTypeView:IncidentType
    {
        public string name { get; set; }
        public string description { get; set; }
    }
}
