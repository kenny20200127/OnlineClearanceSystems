using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineClearanceCore.Core.Entities;
using OnlineClearanceWeb.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineClearanceWeb.Controllers.Api.ReferenceTable
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService service;
        public StudentController(IStudentService service)
        {
            this.service = service;
        }

        //api/Student/getAllStudent
        [Route("getAllStudent")]
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            var st=service.GetStudents();
            return st;
        }
        [Route("getAllApproveStudent")]
        [HttpGet]
        public IEnumerable<Student> GetApprove()
        {
            var st = service.GetApproveStudents();
            return st;
        }
        [Route("getAllDeclineStudent")]
        [HttpGet]
        public IEnumerable<Student> Getdecline()
        {
            var st = service.GetDeclineStudents();
            return st;
        }
        //api/Student/getAllStudent
        [Route("getAllStudentbyCase")]
        [HttpGet]
        public async Task<Student> GetByCase()
        {
            string Studentid = HttpContext.Session.GetString("StudentNumber");
            return await service.GetStudentByCode(Studentid);
        }

        //api/Student/createStudent
        [Route("createStudent")]
        [HttpPost]
        public IActionResult createStudents([FromBody] Student value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.StudentId))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Student" });
                }
                value.StudentId = "SPY" + "/" + "CS" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString() + 0001;
                value.datecreated = DateTime.Now;
                value.createdby = User.Identity.Name;
                service.AddStudents(value);

                return Ok(new { responseCode = 200, responseDescription = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

        //api/Student/Student/7
        [Route("RemoveStudent/{id:int}")]
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var balsheet = service.GetStudentsById(id).Result;
            if (balsheet == null) return NotFound();

            service.RemoveStudents(balsheet);
            return Ok(new { responseCode = 200, responseDescription = "Deleted Successful" });
        }


        // PUT: api/Student/5
        [Route("updateStudent")]
        [HttpPut]
        public IActionResult Put([FromBody] Student value)
        {
            try
            {
               
                var getbal = service.GetStudentByCode(value.StudentId.Trim()).Result;

                getbal.StudentId = value.StudentId;
               
                getbal.Campus = value.Campus;
                getbal.department = value.department;
                getbal.CourseProgram = value.CourseProgram;
                //getbal.email = value.email;
                //getbal.tel = value.tel;
                getbal.College = value.College;
                getbal.Status = value.Status;

                getbal.ApprovedByHOD = value.ApprovedByHOD;
                getbal.ApprovedDateHOD = value.ApprovedDateHOD;
                getbal.hodremark = value.hodremark;
                getbal.ApprovedByAdmin = value.ApprovedByAdmin;
                getbal.ApprovedDateAdmin = value.ApprovedDateAdmin;
                getbal.adminremark = value.adminremark;
                getbal.ApprovedByLibrary= value.ApprovedByLibrary;
                getbal.ApprovedDateLIB = value.ApprovedDateLIB;
                getbal.libremark = value.libremark;

                getbal.createdby = value.createdby;
                getbal.datecreated = value.datecreated;


                service.UpdateStudents(getbal);

                return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

    }
}