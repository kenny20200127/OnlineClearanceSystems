using OnlineClearanceCore.Core.Data;
using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineClearanceCore.Core.Repositories
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
