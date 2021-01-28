using EdoTrafficMgtCore.Core.Data;
using EdoTrafficMgtCore.Core.Entities;
using EdoTrafficMgtWeb.IServices;
using System.Collections.Generic;

namespace EdoTrafficMgtWeb.Services
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
