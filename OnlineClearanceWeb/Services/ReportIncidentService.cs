using EdoTrafficMgtCore.Core.Data;
using EdoTrafficMgtCore.Core.Entities;
using EdoTrafficMgtWeb.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoTrafficMgtWeb.Services
{
    public class ReportIncidentService : IReportIncidentService
    {
        private IUnitOfWork unitOfWork;
        public ReportIncidentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> AddReportIncident(ReportedIncidents bl_sheet)
        {
            unitOfWork.ReportIncidents.Create(bl_sheet);
            return await unitOfWork.Done();
        }

        public IEnumerable<ReportedIncidents> GetReportIncident()
        {
            return unitOfWork.ReportIncidents.All();
        }
        public IEnumerable<ReportedIncidents> GetReportIncidentByCase()
        {
            return unitOfWork.ReportIncidents.GetReportedIncidentByCase();
        }
        public Task<ReportedIncidents> GetReportedIncidentByCode(string bcode)
        {
            return unitOfWork.ReportIncidents.GetReportedIncidentByCode(x=>x.IncidentCode==bcode);
        }

        public Task<ReportedIncidents> GetReportIncidentById(int id)
        {
            return unitOfWork.ReportIncidents.Find(id);
        }

        public ReportedIncidents GetReportIncidentSingleRecord()
        {
            return unitOfWork.ReportIncidents.GetReportedIncidents();
        }

        public void RemoveReportIncident(ReportedIncidents bl_sheet)
        {
            unitOfWork.ReportIncidents.Remove(bl_sheet);
            unitOfWork.Done();
        }

        public async Task<bool> UpdateReportIncident(ReportedIncidents bl_sheet)
        {
            unitOfWork.ReportIncidents.Update(bl_sheet);
            return await unitOfWork.Done();
        }
    }
}
