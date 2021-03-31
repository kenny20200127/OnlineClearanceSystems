using OnlineClearanceCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineClearanceCore.Core.IRepositories
{
    public interface IStudent:IRepository<Student>
    {
        Task<Student> GetStudentByCode(Expression<Func<Student, bool>> predicate);
        Student GetStudents();
        List<Student> GetStudentByCase();
        IEnumerable<Student> GetStudentByApproval();
        IEnumerable<Student> GetStudentByDecline();
    }
}
