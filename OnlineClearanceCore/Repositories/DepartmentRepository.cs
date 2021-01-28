using OnlineClearanceCore.Core.Data;
using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Core.IRepositories;
using OnlineClearanceCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineClearanceCore.Core.Repositories
{
    public class DepartmentRepository:Repository<Department>,IDepartmentRepository
    {
        private readonly ITrafficMgtDbContext context;
        public DepartmentRepository(ITrafficMgtDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<Department> GetDepartmentByCode(Expression<Func<Department, bool>> predicate)
        {
            return await context.Departments.FirstOrDefaultAsync(predicate);
        }

        public Department GetDepartmentByDesc(string desc)
        {
            return context.Departments.FirstOrDefault(x => x.Description.ToUpper() == desc.ToUpper()); 
        }

        public List<DepartmentView> GetDepartmentForReport()
        {
            string ReportIncidentname = context.Students.FirstOrDefault().FirstName;
            string address = context.Students.FirstOrDefault().Address;

            return (from p in context.Departments
                    select new DepartmentView
                    {
                     
                        name = p.Name,
                        description = p.Description
                    }).ToList();
        }
    }
}
