using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rcs_p.Dtos;
using rcs_p.Services.RequestsService;

namespace rcs_p.Services.RequestsService
{
    public interface IRequestService
    {
        Task<ServiceResponse<List<GetRequestResponseDto>>> GetRequests();
        Task<ServiceResponse<GetRequestResponseDto>> GetRequestById(int id);
        Task<ServiceResponse<List<GetRequestResponseDto>>> AddRequest(AddRequestPromptDto newRequest);

        Task<ServiceResponse<GetRequestResponseDto>> UpdateRequest(UpdateRequestPromptDto updatedRequest);
        
        Task<ServiceResponse<List<GetRequestResponseDto>>> DeleteRequest(int id);
    }
}