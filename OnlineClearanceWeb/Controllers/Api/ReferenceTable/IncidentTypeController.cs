using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdoTrafficMgtCore.Core.Entities;
using EdoTrafficMgtWeb.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdoTrafficMgtWeb.Controllers.Api.ReferenceTable
{
    [Route("api/IncidentType")]
    [ApiController]
    public class IncidentTypeController : ControllerBase
    {
        private readonly IIncidentTypeService IncidentTypeService;
        public IncidentTypeController(IIncidentTypeService IncidentTypeService)
        {

            this.IncidentTypeService = IncidentTypeService;
        }
        [Route("getAllIncidentTypes")]
        [HttpGet]
        public IEnumerable<IncidentType> Get()
        {
            return IncidentTypeService.GetIncidentTypes();
        }

        // GET: api/IncidentType
        [Route("getIncidentTypeByCode/{id}")]
        [HttpGet]
        public IActionResult GetIncidentTypeByCode(string id)
        {
            var balsheet = IncidentTypeService.GetIncidentTypeByCode(id).Result;

            if (balsheet == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "Cost Center Code does not Exist" });
            }
            return Ok(new { responseCode = 200, responseDescription = "Successfully", Data = balsheet });
        }

        // GET: api/IncidentType/5
        [Route("Getl")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/IncidentType
        [Route("createIncidentType")]
        [HttpPost]
        public IActionResult createIncidentType([FromBody] IncidentType value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.Name))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Code" });
                }
                if (IncidentTypeService.GetIncidentTypeByCode(value.Name.Trim()).Result != null)
                {
                    return Ok(new { responseCode = 400, responseDescription = "Code already Exist" });
                }
                // value.datecreated = DateTime.Now;
                IncidentTypeService.AddIncidentType(value);

                return Ok(new { responseCode = 200, responseDescription = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

        //api/IncidentType/RemoveBalsheet/7
        [Route("RemoveIncidentType/{id:int}")]
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var balsheet = IncidentTypeService.GetIncidentTypeById(id).Result;
            if (balsheet == null) return NotFound();

            IncidentTypeService.RemoveIncidentType(balsheet);
            return Ok(new { responseCode = 200, responseDescription = "Deleted Successful" });
        }


        // PUT: api/IncidentType/5
        [Route("updateIncidentType")]
        [HttpPut]
        public IActionResult Put([FromBody] IncidentType value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.Name))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Cost Center Code" });
                }
                var getbal = IncidentTypeService.GetIncidentTypeByCode(value.Name.Trim()).Result;
                getbal.Description = value.Description;
                IncidentTypeService.UpdateIncidentType(getbal);
                return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

    }
}