using OnlineClearanceCore.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineClearanceCore.Core.Data
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IUserRoleRepository UserRoles { get; }
        IMenuRepository Menus { get; }
        IRoleMenuRepository RoleMenus { get; }
        IMenuGroupRepository MenuGroups { get; }
        IStudent Students { get; }
        IDepartmentRepository Ind { get; }
        IStatesRepository States { get; }
        ICourseRepository Courses { get; }
        ILocalGovtRepository LocalGovernments { get; }

        Task<bool> Done();
    }
}
