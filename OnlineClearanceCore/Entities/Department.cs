﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineClearanceCore.Core.Entities
{

    public class Department
    {
        [Key]
        public int Id { get; set; }

        [StringLength(5)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
    }
}
