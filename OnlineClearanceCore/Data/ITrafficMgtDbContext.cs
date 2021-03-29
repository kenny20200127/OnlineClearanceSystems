using OnlineClearanceCore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineClearanceCore.Core.Data
{
    public interface ITrafficMgtDbContext:IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<Menu> Menus { get; set; }
        DbSet<RoleMenu> RoleMenus { get; set; }
        DbSet<MenuGroup> MenuGroups { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<States> States { get; set; }
        DbSet<LocalGovernment> LocalGovernments { get; set; }
    }
}
