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
    [Route("api/States")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStatesService StatesService;
        public StatesController(IStatesService StatesService)
        {

            this.StatesService = StatesService;
        }
        [Route("getAllStatess")]
        [HttpGet]
        public IEnumerable<States> Get()
        {
            return StatesService.GetStatess();
        }

        // GET: api/States
        [Route("getStatesByCode/{id}")]
        [HttpGet]
        public IActionResult GetStatesByCode(string id)
        {
            var balsheet = StatesService.GetStatesByCode(id).Result;

            if (balsheet == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "Cost Center Code does not Exist" });
            }
            return Ok(new { responseCode = 200, responseDescription = "Cost Center Code Exist", Data = balsheet });
        }

        // GET: api/States/5
        [Route("Getl")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/States
        [Route("createStates")]
        [HttpPost]
        public IActionResult createStates([FromBody] States value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.Name))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Code" });
                }
                if (StatesService.GetStatesByCode(value.Name.Trim()).Result != null)
                {
                    return Ok(new { responseCode = 400, responseDescription = "Code already Exist" });
                }
                // value.datecreated = DateTime.Now;
                StatesService.AddStates(value);

                return Ok(new { responseCode = 200, responseDescription = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

        //api/States/RemoveBalsheet/7
        [Route("RemoveStates/{id:int}")]
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var balsheet = StatesService.GetStatesById(id).Result;
            if (balsheet == null) return NotFound();

            StatesService.RemoveStates(balsheet);
            return Ok(new { responseCode = 200, responseDescription = "Deleted Successful" });
        }


        // PUT: api/States/5
        [Route("updateStates")]
        [HttpPut]
        public IActionResult Put([FromBody] States value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.Name))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Cost Center Code" });
                }
                var getbal = StatesService.GetStatesByCode(value.Name.Trim()).Result;
                getbal.Description = value.Description;
                StatesService.UpdateStates(getbal);
                return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

    }
}