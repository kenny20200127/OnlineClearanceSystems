using EdoTrafficMgtCore.Core.Data;
using EdoTrafficMgtCore.Core.Entities;
using EdoTrafficMgtCore.Core.IRepositories;
using EdoTrafficMgtCore.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdoTrafficMgtCore.Core.Repositories
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        private readonly ITrafficMgtDbContext context;
        public MenuRepository(ITrafficMgtDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
