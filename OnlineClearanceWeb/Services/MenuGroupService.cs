using OnlineClearanceCore.Core.Data;
using OnlineClearanceCore.Core.Entities;
using OnlineClearanceWeb.IServices;
using System.Collections.Generic;

namespace OnlineClearanceWeb.Services
{
    public class MenuGroupService : IMenuGroupService
    {
        private readonly IUnitOfWork unitOfWork;
        public MenuGroupService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<MenuGroup> GetMenuGroupss()
        {
            return unitOfWork.MenuGroups.All();
        }

        public IEnumerable<MenuGroup> GetActiveMenuGroups()
        {
            return null;
        }
    }
}
