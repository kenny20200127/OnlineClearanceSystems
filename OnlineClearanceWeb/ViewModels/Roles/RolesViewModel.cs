using OnlineClearanceCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineClearanceWeb.ViewModels.Roles
{
    public class RolesViewModel
    {
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
    }
}
