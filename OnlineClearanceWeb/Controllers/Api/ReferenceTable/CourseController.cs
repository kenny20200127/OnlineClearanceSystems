using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineClearanceCore.Core.Entities;
using OnlineClearanceWeb.IServices;

namespace OnlineClearanceWeb.Controllers.Api.ReferenceTable
{
    [Route("api/Course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService CourseService;
        public CourseController(ICourseService CourseService)
        {
            this.CourseService = CourseService;
        }
        [Route("getAllCourses")]
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return CourseService.GetCourses();
        }

        // GET: api/Course
        [Route("getCourseByCode/{department}")]
        [HttpGet]
        public IEnumerable<Course> GetCourseByCode(string department)
        {
            return  CourseService.GetCourseByDesc(department);

            //if (balsheet == null)
            //{
            //    return Ok(new { responseCode = 404, responseDescription = "Cost Center Code does not Exist" });
            //}
            //return Ok(new { responseCode = 200, responseDescription = "Successfully", Data = balsheet });
        }

        // GET: api/Course/5
        [Route("Getl")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Course
        [Route("createCourse")]
        [HttpPost]
        public IActionResult createCourse([FromBody] Course value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.Name))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Code" });
                }
                if (CourseService.GetCourseByCode(value.Name.Trim()).Result != null)
                {
                    return Ok(new { responseCode = 400, responseDescription = "Code already Exist" });
                }
                // value.datecreated = DateTime.Now;
                CourseService.AddCourse(value);

                return Ok(new { responseCode = 200, responseDescription = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

        //api/Course/RemoveBalsheet/7
        [Route("RemoveCourse/{id:int}")]
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var balsheet = CourseService.GetCourseById(id).Result;
            if (balsheet == null) return NotFound();

            CourseService.RemoveCourse(balsheet);
            return Ok(new { responseCode = 200, responseDescription = "Deleted Successful" });
        }


        // PUT: api/Course/5
        [Route("updateCourse")]
        [HttpPut]
        public IActionResult Put([FromBody] Course value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.Name))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Cost Center Code" });
                }
                var getbal = CourseService.GetCourseByCode(value.Name.Trim()).Result;
                getbal.Description = value.Description;
                CourseService.UpdateCourse(getbal);
                return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

    }
}