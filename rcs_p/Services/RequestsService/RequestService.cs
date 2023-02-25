using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using rcs_p.Dtos;
using rcs_p.Models;
using AutoMapper;

namespace rcs_p.Services.RequestsService
{
    public class RequestService : IRequestService
    {
         private static List<Request> requests = new List<Request>
        {
            new Request(),
            new Request {Id =1, Name = "Recieve" }
        };
        private readonly IMapper _mapper;

        public RequestService(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        public async Task<ServiceResponse<List<GetRequestResponseDto>>> AddRequest(AddRequestPromptDto newRequest)
        {
            var serviceResponse  = new ServiceResponse<List<GetRequestResponseDto>>();
            var request = _mapper.Map<Request>(newRequest);
            request.Id = requests.Max(r => r.Id) +1;
            requests.Add(request);


            requests.Add(_mapper.Map<Request>(newRequest));
            serviceResponse.Data = requests.Select(r => _mapper.Map<GetRequestResponseDto>(r)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetRequestResponseDto>>> GetRequests()
        {
            var serviceResponse  = new ServiceResponse<List<GetRequestResponseDto>>();
            serviceResponse.Data = requests.Select(r => _mapper.Map<GetRequestResponseDto>(r)).ToList();
            return serviceResponse;
        }
        
        public async Task<ServiceResponse<GetRequestResponseDto>> GetRequestById(int id)
        {
            var serviceResponse  = new ServiceResponse<GetRequestResponseDto>();
            var request = requests.FirstOrDefault(r => r.Id == id);
            serviceResponse.Data = _mapper.Map<GetRequestResponseDto>(request);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetRequestResponseDto>> UpdateRequest(UpdateRequestPromptDto updatedRequest)
        {
            var serviceResponse  = new ServiceResponse<GetRequestResponseDto>();

            try {

            var request = requests.FirstOrDefault(r => r.Id == updatedRequest.Id);
            if(request is null)
                throw new Exception($"Request with Id '{updatedRequest.Id}' not found.");

            /*_mapper.Map(updatedRequest, request);*/

            request.Name = updatedRequest.Name;
            request.clas = updatedRequest.clas;

            serviceResponse.Data = _mapper.Map<GetRequestResponseDto>(request);
            
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
             
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetRequestResponseDto>>> DeleteRequest(int id)
        {
                        var serviceResponse  = new ServiceResponse<List<GetRequestResponseDto>>();

            try {

            var request = requests.FirstOrDefault(r => r.Id == id);
            if(request is null)
                throw new Exception($"Request with Id '{id}' not found.");

            /*_mapper.Map(updatedRequest, request);*/
            requests.Remove(request);

            serviceResponse.Data = requests.Select(r => _mapper.Map<GetRequestResponseDto>(r)).ToList();
            
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
             
            return serviceResponse;
        }
    }
}