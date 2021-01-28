using EdoTrafficMgtCore.Core.Data;
using EdoTrafficMgtCore.Core.Entities;
using EdoTrafficMgtCore.Models;
using EdoTrafficMgtWeb.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoTrafficMgtWeb.Services
{
    public class IncidentTypeService : IIncidentTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        public IncidentTypeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        public Task<IncidentType> GetIncidentTypeByCode(string balcode)
        {
            return unitOfWork.Ind.GetIncidentTypeByCode(x => x.Name == balcode);

        }
        public async Task<bool> AddIncidentType(IncidentType balsheet)
        {
            unitOfWork.Ind.Create(balsheet);
            return await unitOfWork.Done();
        }

        public IEnumerable<IncidentType> GetIncidentTypes()
        {
            return unitOfWork.Ind.All();
        }


        public Task<IncidentType> GetIncidentTypeById(int id)
        {
            return unitOfWork.Ind.Find(id);
        }

        public async Task<bool> UpdateIncidentType(IncidentType balsheet)
        {
            unitOfWork.Ind.Update(balsheet);
            return await unitOfWork.Done();
        }

        public void RemoveIncidentType(IncidentType bl_sheet)
        {
            unitOfWork.Ind.Remove(bl_sheet);
            unitOfWork.Done();
        }

        public IncidentType GetIncidentTypeByDesc(string desc)
        {
            return unitOfWork.Ind.GetIncidentTypeByDesc(desc);
        }

        public List<IncidentTypeView> GetIncidentTypeForReport()
        {
            return unitOfWork.Ind.GetIncidentTypeForReport();
        }
    }
}
