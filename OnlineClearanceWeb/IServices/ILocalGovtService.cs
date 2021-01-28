using EdoTrafficMgtCore.Core.Entities;
using EdoTrafficMgtCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoTrafficMgtWeb.IServices
{
    public interface ILocalGovtService
    {
        IEnumerable<LocalGovernment> GetLocalGovernments();
        //List<LocalGovernmentView> GetLocalGovernmentForReport();
        void RemoveLocalGovernment(LocalGovernment bl_sheet);
        Task<LocalGovernment> GetLocalGovernmentById(int id);
        Task<LocalGovernment> GetLocalGovernmentByCode(string bcode);
        Task<bool> AddLocalGovernment(LocalGovernment bl_sheet);
        Task<bool> UpdateLocalGovernment(LocalGovernment bl_sheet);
        LocalGovernment GetLocalGovernmentByDesc(string desc);
    }
}
