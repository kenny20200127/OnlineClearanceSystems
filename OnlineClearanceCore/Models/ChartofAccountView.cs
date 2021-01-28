using OnlineClearanceCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineClearanceCore.Models
{
    public class ChartofAccountView
    {
        public string compname { get; set; }
        public string compaddress { get; set; }
        public string mainAccountCode_desc { get; set; }

        public string subtype_desc { get; set; }

        public string balSheetCode_desc { get; set; }
    }
    public class ChartofAccountView2
    {
        public int Id { get; set; }
        public string acctcode { get; set; }
        public string description { get; set; }
        public string mainAccountCode { get; set; }

        public string subtype { get; set; }

        public bool ispersonel { get; set; }

        public string balSheetCode { get; set; }
        public string mainAccountCode_desc { get; set; }

        public string subtype_desc { get; set; }

        public string balSheetCode_desc { get; set; }

    }
}
