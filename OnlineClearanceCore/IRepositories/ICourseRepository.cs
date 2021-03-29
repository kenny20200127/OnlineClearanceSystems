using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineClearanceCore.Core.IRepositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<Course> GetCourseByCode(Expression<Func<Course, bool>> predicate);
        IEnumerable<Course> GetCourseByDesc(string desc);
        //List<DepartmentView> GetDepartmentForReport();
    }
}
