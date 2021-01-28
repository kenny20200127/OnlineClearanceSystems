using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineClearanceCore.Core.Data;
using OnlineClearanceCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineClearanceWeb.Data
{
    public class ApplicationDbContext: IdentityDbContext<User,Role, int>,ITrafficMgtDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
       {
       }

    public DbContext Instance => this;

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<MenuGroup> MenuGroups { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<RoleMenu> RoleMenus { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }
    public  DbSet<States> States { get; set; }
    public  DbSet<LocalGovernment> LocalGovernments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Menu>()
            .HasIndex(x => x.Code)
            .IsUnique();

        builder.Entity<RoleMenu>()
            .Property(e => e.Id)
            .UseSqlServerIdentityColumn();



        builder.Entity<Menu>()
            .Property(e => e.Id)
            .UseSqlServerIdentityColumn();

      

        builder.Entity<UserRole>()
            .HasOne(x => x.Role)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.RoleId);

        builder.Entity<UserRole>()
            .HasOne(x => x.User)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.UserId);

        builder.Entity<RoleMenu>()
            .HasKey(x => x.Id);

        builder.Entity<RoleMenu>()
            .HasOne(x => x.Role)
            .WithMany(x => x.RoleMenus)
            .HasForeignKey(x => x.RoleId);

        builder.Entity<RoleMenu>()
            .HasOne(x => x.Menu)
            .WithMany(x => x.RoleMenus)
            .HasForeignKey(x => x.MenuId);
    }
   }
}

