using OnlineClearanceCore.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineClearanceCore.Core.Entities
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Description { get; set; }

        public MenuGroup MenuGroup { get; set; }
        public int? MenuGroupId { get; set; }

        public bool IsActive { get; set; }
        public string menuicon { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        [JsonIgnore]
        public List<RoleMenu> RoleMenus { get; set; }
    }
}

