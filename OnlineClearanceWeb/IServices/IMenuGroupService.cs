using OnlineClearanceCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineClearanceWeb.IServices
{
    public interface IMenuGroupService
    {
        IEnumerable<MenuGroup> GetActiveMenuGroups();
        IEnumerable<MenuGroup> GetMenuGroupss();
    }
}
