using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineClearanceWeb.IServices
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCourses();
        //List<DepartmentView> GetDepartmentForReport();
        void RemoveCourse(Course bl_sheet);
        Task<Course> GetCourseById(int id);
        Task<Course> GetCourseByCode(string bcode);
        Task<bool> AddCourse(Course bl_sheet);
        Task<bool> UpdateCourse(Course bl_sheet);
        IEnumerable<Course> GetCourseByDesc(string desc);
    }
}
