using OnlineClearanceCore.Core.Data;
using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Core.IRepositories;
using OnlineClearanceCore.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineClearanceCore.Core.Repositories
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
