using EdoTrafficMgtCore.Core.Entities;
using EdoTrafficMgtCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoTrafficMgtWeb.IServices
{
    public interface IIncidentTypeService
    {
        IEnumerable<IncidentType> GetIncidentTypes();
        List<IncidentTypeView> GetIncidentTypeForReport();
        void RemoveIncidentType(IncidentType bl_sheet);
        Task<IncidentType> GetIncidentTypeById(int id);
        Task<IncidentType> GetIncidentTypeByCode(string bcode);
        Task<bool> AddIncidentType(IncidentType bl_sheet);
        Task<bool> UpdateIncidentType(IncidentType bl_sheet);
        IncidentType GetIncidentTypeByDesc(string desc);
    }
}
