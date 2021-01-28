using EdoTrafficMgtCore.Core.IRepositories;
using EdoTrafficMgtCore.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EdoTrafficMgtCore.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITrafficMgtDbContext context;
        public UnitOfWork(ITrafficMgtDbContext context)
        {
            this.context = context;

            Users = new UserRepository(context);
            Menus = new MenuRepository(context);
            RoleMenus = new RoleMenuRepository(context);
            MenuGroups = new MenuGroupRepository(context);
            UserRoles = new UserRoleRepository(context);
            Ind = new IncidentTypeRepository(context);
            ReportIncidents = new ReportIncidentRepository(context);
            States = new StatesRepository(context);
            LocalGovernments = new LocalGovtRepository(context);
        }

        public IUserRepository Users { get; set; }

        public IUserRoleRepository UserRoles { get; set; }

        public IMenuRepository Menus { get; set; }

        public IRoleMenuRepository RoleMenus { get; set; }

        public IMenuGroupRepository MenuGroups { get; set; }
        public IReportIncident ReportIncidents { get; set; }
        public IIncidentTypeRepository Ind { get; set; }
        public IStatesRepository States { get; set; }
        public ILocalGovtRepository LocalGovernments { get; set; }

        public async Task<bool> Done()
        {
           return await context.Instance.SaveChangesAsync() > 0;
        }
    }
}
