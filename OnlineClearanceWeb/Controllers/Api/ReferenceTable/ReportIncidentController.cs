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
    [Route("api/ReportIncident")]
    [ApiController]
    public class ReportIncidentController : ControllerBase
    {
        private readonly IReportIncidentService service;
        public ReportIncidentController(IReportIncidentService service)
        {
            this.service = service;
        }

        //api/ReportIncident/getAllReportIncident
        [Route("getAllReportIncident")]
        [HttpGet]
        public IEnumerable<ReportedIncidents> Get()
        {
            return service.GetReportIncident();
        }
        //api/ReportIncident/getAllReportIncident
        [Route("getAllReportIncidentbyCase")]
        [HttpGet]
        public IEnumerable<ReportedIncidents> GetByCase()
        {
            return service.GetReportIncidentByCase();
        }

        //api/ReportIncident/createReportIncident
        [Route("createReportIncident")]
        [HttpPost]
        public IActionResult createReportIncident([FromBody] ReportedIncidents value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.IncidentType))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Incident Type" });
                }
                value.IncidentCode = "CAS" + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString() + 0001;
                value.datecreated = DateTime.Now;
                value.createdby = User.Identity.Name;
                service.AddReportIncident(value);

                return Ok(new { responseCode = 200, responseDescription = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

        //api/ReportIncident/RemoveReportIncident/7
        [Route("RemoveReportIncident/{id:int}")]
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var balsheet = service.GetReportIncidentById(id).Result;
            if (balsheet == null) return NotFound();

            service.RemoveReportIncident(balsheet);
            return Ok(new { responseCode = 200, responseDescription = "Deleted Successful" });
        }


        // PUT: api/BalanceSheet/5
        [Route("updateReportIncident")]
        [HttpPut]
        public IActionResult Put([FromBody] ReportedIncidents value)
        {
            try
            {
               
                var getbal = service.GetReportedIncidentByCode(value.IncidentCode.Trim()).Result;

                getbal.IncidentCode = value.IncidentCode;
                getbal.FirstName = value.FirstName;
                getbal.OtherNames = value.OtherNames;
                getbal.Address = value.Address;
                getbal.IncidentDate = value.IncidentDate;
                getbal.IncidentLocation = value.IncidentLocation;
                getbal.IncidentType = value.IncidentType;
                getbal.box = value.box;
                getbal.email = value.email;
                getbal.NearestBusStop = value.NearestBusStop;
                getbal.lga = value.lga;
                getbal.Photo1 = value.Photo1;
                getbal.Photo2 = value.Photo2;
                getbal.ReportedBy = value.ReportedBy;
                getbal.state = value.state;
                getbal.AnyotherInfo = value.AnyotherInfo;
                getbal.state = value.state;
                getbal.tel = value.tel;
                getbal.town = value.town;
                getbal.createdby = value.createdby;
                getbal.datecreated = value.datecreated;


                service.UpdateReportIncident(getbal);

                return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

    }
}