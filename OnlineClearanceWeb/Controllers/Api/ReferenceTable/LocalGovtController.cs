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
    [Route("api/LocalGovernment")]
    [ApiController]
    public class LocalGovtController : ControllerBase
    {
        private readonly ILocalGovtService LocalGovernmentService;
        public LocalGovtController(ILocalGovtService LocalGovernmentService)
        {

            this.LocalGovernmentService = LocalGovernmentService;
        }
        [Route("getAllLocalGovernments")]
        [HttpGet]
        public IEnumerable<LocalGovernment> Get()
        {
            return LocalGovernmentService.GetLocalGovernments();
        }
        [Route("getAllLocalGovernmentByState/{state}")]
        [HttpGet]
        public IEnumerable<LocalGovernment> Getstate(string state)
        {
            return LocalGovernmentService.GetLocalGovernmentByDesc(state);
        }

        // GET: api/LocalGovernment
        [Route("getLocalGovernmentByCode/{id}")]
        [HttpGet]
        public IActionResult GetLocalGovernmentByCode(string id)
        {
            var balsheet = LocalGovernmentService.GetLocalGovernmentByCode(id).Result;

            if (balsheet == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "Cost Center Code does not Exist" });
            }
            return Ok(new { responseCode = 200, responseDescription = "Cost Center Code Exist", Data = balsheet });
        }

        // GET: api/LocalGovernment/5
        [Route("Getl")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LocalGovernment
        [Route("createLocalGovernment")]
        [HttpPost]
        public IActionResult createLocalGovernment([FromBody] LocalGovernment value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.Name))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Code" });
                }
                if (LocalGovernmentService.GetLocalGovernmentByCode(value.Name.Trim()).Result != null)
                {
                    return Ok(new { responseCode = 400, responseDescription = "Code already Exist" });
                }
                // value.datecreated = DateTime.Now;
                LocalGovernmentService.AddLocalGovernment(value);

                return Ok(new { responseCode = 200, responseDescription = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

        //api/LocalGovernment/RemoveBalsheet/7
        [Route("RemoveLocalGovernment/{id:int}")]
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var balsheet = LocalGovernmentService.GetLocalGovernmentById(id).Result;
            if (balsheet == null) return NotFound();

            LocalGovernmentService.RemoveLocalGovernment(balsheet);
            return Ok(new { responseCode = 200, responseDescription = "Deleted Successful" });
        }


        // PUT: api/LocalGovernment/5
        [Route("updateLocalGovernment")]
        [HttpPut]
        public IActionResult Put([FromBody] LocalGovernment value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.Name))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Cost Center Code" });
                }
                var getbal = LocalGovernmentService.GetLocalGovernmentByCode(value.Name.Trim()).Result;
                getbal.Description = value.Description;
                LocalGovernmentService.UpdateLocalGovernment(getbal);
                return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

    }
}