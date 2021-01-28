using EdoTrafficMgtCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoTrafficMgtWeb.IServices
{
    public interface IReportIncidentService
    {
        IEnumerable<ReportedIncidents> GetReportIncident();
        IEnumerable<ReportedIncidents> GetReportIncidentByCase();
        ReportedIncidents GetReportIncidentSingleRecord();
        void RemoveReportIncident(ReportedIncidents bl_sheet);
        Task<ReportedIncidents> GetReportIncidentById(int id);
        Task<bool> AddReportIncident(ReportedIncidents bl_sheet);
        Task<ReportedIncidents> GetReportedIncidentByCode(string bcode);
        Task<bool> UpdateReportIncident(ReportedIncidents bl_sheet);
    }
}
