using OnlineClearanceCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineClearanceWeb.IServices
{
    public interface IMenuService
    {
        IEnumerable<Menu> GetActiveMenus();
        IEnumerable<Menu> GetMenus();
        Task<Menu> GetMenuById(int id);
        Task<bool> AddMenu(Menu menu);
        Task<bool> UpdateMenu(Menu menu);
        Menu GetMenuByCode(string code);
    }
}
