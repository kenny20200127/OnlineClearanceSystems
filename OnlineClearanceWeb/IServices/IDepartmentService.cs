using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineClearanceWeb.IServices
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetDepartments();
        List<DepartmentView> GetDepartmentForReport();
        void RemoveDepartment(Department bl_sheet);
        Task<Department> GetDepartmentById(int id);
        Task<Department> GetDepartmentByCode(string bcode);
        Task<bool> AddDepartment(Department bl_sheet);
        Task<bool> UpdateDepartment(Department bl_sheet);
        Department GetDepartmentByDesc(string desc);
    }
}
