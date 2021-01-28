using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdoTrafficMgtCore.Core.Entities
{
    public class MenuGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        [JsonIgnore]
        public List<Menu> Menus { get; set; }
    }
}
