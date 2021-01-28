using OnlineClearanceCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineClearanceWeb.IServices
{
    public interface IStudentService
    {
        IEnumerable<Student> GetReportIncident();
        IEnumerable<Student> GetReportIncidentByCase();
        Student GetReportIncidentSingleRecord();
        void RemoveReportIncident(Student bl_sheet);
        Task<Student> GetReportIncidentById(int id);
        Task<bool> AddReportIncident(Student bl_sheet);
        Task<Student> GetStudentByCode(string bcode);
        Task<bool> UpdateReportIncident(Student bl_sheet);
    }
}
