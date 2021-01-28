using OnlineClearanceCore.Core.Data;
using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineClearanceCore.Core.Repositories
{
    public class RoleMenuRepository : Repository<RoleMenu>, IRoleMenuRepository
    {
        private readonly ITrafficMgtDbContext context;

        public RoleMenuRepository(ITrafficMgtDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
