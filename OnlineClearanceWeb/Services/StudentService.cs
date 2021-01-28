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
        public async Task<bool> AddReportIncident(Student bl_sheet)
        {
            unitOfWork.ReportIncidents.Create(bl_sheet);
            return await unitOfWork.Done();
        }

        public IEnumerable<Student> GetReportIncident()
        {
            return unitOfWork.ReportIncidents.All();
        }
        public IEnumerable<Student> GetReportIncidentByCase()
        {
            return unitOfWork.ReportIncidents.GetStudentByCase();
        }
        public Task<Student> GetStudentByCode(string bcode)
        {
            return unitOfWork.ReportIncidents.GetStudentByCode(x=>x.StudentId==bcode);
        }

        public Task<Student> GetReportIncidentById(int id)
        {
            return unitOfWork.ReportIncidents.Find(id);
        }

        public Student GetReportIncidentSingleRecord()
        {
            return unitOfWork.ReportIncidents.GetStudents();
        }

        public void RemoveReportIncident(Student bl_sheet)
        {
            unitOfWork.ReportIncidents.Remove(bl_sheet);
            unitOfWork.Done();
        }

        public async Task<bool> UpdateReportIncident(Student bl_sheet)
        {
            unitOfWork.ReportIncidents.Update(bl_sheet);
            return await unitOfWork.Done();
        }
    }
}
