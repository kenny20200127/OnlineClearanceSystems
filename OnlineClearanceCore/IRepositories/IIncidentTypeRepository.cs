using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineClearanceCore.Core.IRepositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<Department> GetDepartmentByCode(Expression<Func<Department, bool>> predicate);
        Department GetDepartmentByDesc(string desc);
        List<DepartmentView> GetDepartmentForReport();
    }
}
