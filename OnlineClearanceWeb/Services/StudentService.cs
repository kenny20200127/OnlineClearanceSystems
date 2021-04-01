using OnlineClearanceCore.Core.Data;
using OnlineClearanceCore.Core.Entities;
using OnlineClearanceWeb.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineClearanceWeb.Services
{
    public class StudentService : IStudentService
    {
        private IUnitOfWork unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> AddStudents(Student bl_sheet)
        {
            unitOfWork.Students.Create(bl_sheet);
            return await unitOfWork.Done();
        }

        public IEnumerable<Student> GetStudents()
        {
            return unitOfWork.Students.GetAllUnclearedStudent();
        }
        public IEnumerable<Student> GetApproveStudents()
        {
            return unitOfWork.Students.GetStudentByApproval();
        }
        public IEnumerable<Student> GetDeclineStudents()
        {
            return unitOfWork.Students.GetStudentByDecline();
        }
        public IEnumerable<Student> GetStudentsByCase()
        {
            return unitOfWork.Students.GetStudentByCase();
        }
        public Task<Student> GetStudentByCode(string bcode)
        {
            return unitOfWork.Students.GetStudentByCode(x=>x.StudentId==bcode);
        }
        public IEnumerable<Student> GetStudentReport(string bcode)
        {
            return unitOfWork.Students.GetStudentReport(bcode);
        }
        public IEnumerable<Student> GetStudentGenReport(string status)
        {
            return unitOfWork.Students.GetStudentGenReport(status);
        }

        public Task<Student> GetStudentsById(int id)
        {
            return unitOfWork.Students.Find(id);
        }

        public Student GetStudentsSingleRecord()
        {
            return unitOfWork.Students.GetStudents();
        }

        public void RemoveStudents(Student bl_sheet)
        {
            unitOfWork.Students.Remove(bl_sheet);
            unitOfWork.Done();
        }

        public async Task<bool> UpdateStudents(Student bl_sheet)
        {
            unitOfWork.Students.Update(bl_sheet);
            return await unitOfWork.Done();
        }
    }
}
