using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineClearanceWeb.IServices
{
    public interface IStatesService
    {
        IEnumerable<States> GetStatess();
        //List<StatesView> GetStatesForReport();
        void RemoveStates(States bl_sheet);
        Task<States> GetStatesById(int id);
        Task<States> GetStatesByCode(string bcode);
        Task<bool> AddStates(States bl_sheet);
        Task<bool> UpdateStates(States bl_sheet);
        States GetStatesByDesc(string desc);
    }
}
