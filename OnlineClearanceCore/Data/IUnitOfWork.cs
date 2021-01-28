using EdoTrafficMgtCore.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EdoTrafficMgtCore.Core.Data
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IUserRoleRepository UserRoles { get; }
        IMenuRepository Menus { get; }
        IRoleMenuRepository RoleMenus { get; }
        IMenuGroupRepository MenuGroups { get; }
        IReportIncident ReportIncidents { get; }
        IIncidentTypeRepository Ind { get; }
        IStatesRepository States { get; }
        ILocalGovtRepository LocalGovernments { get; }

        Task<bool> Done();
    }
}
