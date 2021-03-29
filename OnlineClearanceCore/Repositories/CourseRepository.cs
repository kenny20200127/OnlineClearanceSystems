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
    public class CourseRepository:Repository<Course>,ICourseRepository
    {
        private readonly ITrafficMgtDbContext context;
        public CourseRepository(ITrafficMgtDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<Course> GetCourseByCode(Expression<Func<Course, bool>> predicate)
        {
            return await context.Courses.FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<Course> GetCourseByDesc(string desc)
        {
            return context.Courses.Where(x => x.departmentcode == desc).ToList(); 
        }

       
    }
}
