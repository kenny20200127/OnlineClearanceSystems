using OnlineClearanceCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineClearanceWeb.IServices
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        IEnumerable<Student> GetApproveStudents();
        IEnumerable<Student> GetDeclineStudents();
        IEnumerable<Student> GetStudentsByCase();
        Student GetStudentsSingleRecord();
        void RemoveStudents(Student bl_sheet);
        Task<Student> GetStudentsById(int id);
        Task<bool> AddStudents(Student bl_sheet);
        Task<Student> GetStudentByCode(string bcode);
        IEnumerable<Student> GetStudentReport(string bcode);
        Task<bool> UpdateStudents(Student bl_sheet);
        IEnumerable<Student> GetStudentGenReport(string status);
    }
}
