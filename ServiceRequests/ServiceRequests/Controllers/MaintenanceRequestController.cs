using MaintenanceRequests.Dtos;
using MaintenanceRequests.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MaintenanceRequests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaintenanceRequestController : ControllerBase
    {
        private readonly IMaintenanceRequestService _maintenanceRequestService;

        public MaintenanceRequestController(IMaintenanceRequestService maintenanceRequestService)
        {
            _maintenanceRequestService = maintenanceRequestService;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var requests = _maintenanceRequestService.GetAllMaintenanceRequests();
            if (requests.Count == 0)
            {
                return NoContent();
            }
            return Ok(_maintenanceRequestService.GetAllMaintenanceRequests());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var request = _maintenanceRequestService.GetMaintenanceRequestById(id);
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }

        [HttpPost]
        public IActionResult CreateNewRequest(AddMaintenanceRequestDto addRequest)
        {
            var requests = _maintenanceRequestService.CreateNewMaintenanceRequest(addRequest);

            return Ok(requests);
        }

        [HttpPut]
        public IActionResult UpdateRequest(UpdateMaintenanceRequestDto updateRequest)
        {
            var request = _maintenanceRequestService.GetMaintenanceRequestById(updateRequest.Id);
            if (request == null)
            {
                return NotFound();
            }

            var updatedrequest = _maintenanceRequestService.UpdateMaintenanceRequest(updateRequest);

            // create a service for sending notification to the user that the request is closed.
            //if(updateRequest.CurrentStatus == Models.ServiceStatus.Complete)
            //{
            //   
            //}

            return Ok(updatedrequest);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRequest(Guid id)
        {

            var request = _maintenanceRequestService.GetMaintenanceRequestById(id);
            if (request == null)
            {
                return NotFound();
            }

            var requests = _maintenanceRequestService.DeleteMaintenanceRequestById(id);

            return Accepted(requests);
        }
    }
}
