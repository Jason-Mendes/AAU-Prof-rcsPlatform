
global using rcs_p.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rcs_p.Dtos;

namespace rcs_p.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RequestsController : ControllerBase
    {

        private readonly IRequestService _requestService;

        public RequestsController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        
        [HttpGet]
        [Route("GetAll")]
        public  async Task<ActionResult<ServiceResponse<List<GetRequestResponseDto>>>> Get()
        {
            return Ok(await _requestService.GetRequests());
        }
        
        [HttpGet("{id}")]
        public  async Task<ActionResult<ServiceResponse<GetRequestResponseDto>>> GetOneRequest(int id)
        {
            return Ok(await _requestService.GetRequestById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetRequestResponseDto>>>> AddRequest(AddRequestPromptDto newRequest)
        {
            return Ok(await _requestService.AddRequest(newRequest));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetRequestResponseDto>>>> UpdateRequest(UpdateRequestPromptDto updatedRequest)
        {
            var ServiceResponse = await _requestService.UpdateRequest(updatedRequest);
            if (ServiceResponse.Data is null) {
                return NotFound(ServiceResponse);
            }
            return Ok(Response);
        }

        
        [HttpDelete("{id}")]
        public  async Task<ActionResult<ServiceResponse<GetRequestResponseDto>>> DeleteRequest(int id)
        {
            var ServiceResponse = await _requestService.DeleteRequest(id);
            if (ServiceResponse.Data is null) {
                return NotFound(ServiceResponse);
            }
            return Ok(Response);
        }
    }
}