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
    [Route("api/Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService DepartmentService;
        public DepartmentController(IDepartmentService DepartmentService)
        {

            this.DepartmentService = DepartmentService;
        }
        [Route("getAllDepartments")]
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return DepartmentService.GetDepartments();
        }

        // GET: api/Department
        [Route("getDepartmentByCode/{id}")]
        [HttpGet]
        public IActionResult GetDepartmentByCode(string id)
        {
            var balsheet = DepartmentService.GetDepartmentByCode(id).Result;

            if (balsheet == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "Cost Center Code does not Exist" });
            }
            return Ok(new { responseCode = 200, responseDescription = "Successfully", Data = balsheet });
        }

        // GET: api/Department/5
        [Route("Getl")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Department
        [Route("createDepartment")]
        [HttpPost]
        public IActionResult createDepartment([FromBody] Department value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.Name))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Code" });
                }
                if (DepartmentService.GetDepartmentByCode(value.Name.Trim()).Result != null)
                {
                    return Ok(new { responseCode = 400, responseDescription = "Code already Exist" });
                }
                // value.datecreated = DateTime.Now;
                DepartmentService.AddDepartment(value);

                return Ok(new { responseCode = 200, responseDescription = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

        //api/Department/RemoveBalsheet/7
        [Route("RemoveDepartment/{id:int}")]
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var balsheet = DepartmentService.GetDepartmentById(id).Result;
            if (balsheet == null) return NotFound();

            DepartmentService.RemoveDepartment(balsheet);
            return Ok(new { responseCode = 200, responseDescription = "Deleted Successful" });
        }


        // PUT: api/Department/5
        [Route("updateDepartment")]
        [HttpPut]
        public IActionResult Put([FromBody] Department value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.Name))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Cost Center Code" });
                }
                var getbal = DepartmentService.GetDepartmentByCode(value.Name.Trim()).Result;
                getbal.Description = value.Description;
                DepartmentService.UpdateDepartment(getbal);
                return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

    }
}