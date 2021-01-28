using EdoTrafficMgtCore.Core.Data;
using EdoTrafficMgtCore.Core.Entities;
using EdoTrafficMgtCore.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdoTrafficMgtCore.Core.Repositories
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
