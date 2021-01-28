using EdoTrafficMgtCore.Core.Data;
using EdoTrafficMgtCore.Core.Entities;
using EdoTrafficMgtCore.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdoTrafficMgtCore.Core.Repositories
{
    public class MenuGroupRepository:Repository<MenuGroup>,IMenuGroupRepository
    {
        private readonly ITrafficMgtDbContext context;

        public MenuGroupRepository(ITrafficMgtDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
