using OnlineClearanceCore.Core.Data;
using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineClearanceCore.Core.Repositories
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        private readonly ITrafficMgtDbContext context;
        public UserRepository(ITrafficMgtDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<User> User(Expression<Func<User, bool>> predicate)
        {
            var reu = await context.Users
               .Include(x => x.UserRoles)
               .ThenInclude(x => x.Role)
               .FirstOrDefaultAsync(predicate);

            return reu;
        }

        public async Task<User> UserWithRoles(Expression<Func<User, bool>> predicate)
        {
            return await context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role).FirstOrDefaultAsync(predicate);
          
        }
    

        public async Task<User> UserWithRolesandMenus(Expression<Func<User, bool>> predicate)
        {
            return await context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .ThenInclude(x => x.RoleMenus)
                .ThenInclude(x => x.Menu)
                .ThenInclude(x => x.MenuGroup)
                .FirstOrDefaultAsync(predicate);
        }
    }
}
