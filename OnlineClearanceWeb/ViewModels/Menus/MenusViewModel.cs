using EdoTrafficMgtCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoTrafficMgtWeb.ViewModels.Menus
{
    public class MenusViewModel
    {
        public IEnumerable<Menu> Menus { get; set; }
        public IEnumerable<MenuGroup> MenuGroups { get; set; }
    }
}
