using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EdoTrafficMgtCore.Core.Entities
{

    public class IncidentType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(5)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
    }
}
