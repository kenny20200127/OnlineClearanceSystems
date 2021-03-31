using OnlineClearanceCore.Core.Data;
using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineClearanceCore.Core.Repositories
{
    public class StudentRepository:Repository<Student>,IStudent
    {
        private readonly ITrafficMgtDbContext context;
        public StudentRepository(ITrafficMgtDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Student> GetStudentByCode(Expression<Func<Student, bool>> predicate)
        {
            return await context.Students.FirstOrDefaultAsync(predicate);
        }

        public Student GetStudents()
        {
            return context.Students.FirstOrDefault();

        }
        public  List<Student> GetStudentByCase()
        {
            var list= context.Students;
            return list.ToList();
        }
        public IEnumerable<Student> GetStudentByApproval()
        {
            var list = context.Students.Where(x=>x.Status=="Approve");
            return list.ToList();
        }
        public IEnumerable<Student> GetStudentByDecline()
        {
            var list = context.Students.Where(x=>x.Status=="Decline");
            return list.ToList();
        }

    }
}
