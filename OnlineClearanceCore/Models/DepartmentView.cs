using OnlineClearanceCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineClearanceCore.Models
{
    public class DepartmentView:Department
    {
        public string name { get; set; }
        public string description { get; set; }
    }
}
