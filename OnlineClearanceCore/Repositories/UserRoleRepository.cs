using OnlineClearanceCore.Core.Data;
using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineClearanceCore.Core.Repositories
{
    public class UserRoleRepository:Repository<UserRole>,IUserRoleRepository
    {
        private readonly ITrafficMgtDbContext context;
        public UserRoleRepository(ITrafficMgtDbContext context) :base(context)
        {
            this.context = context;
        }


    }
}
