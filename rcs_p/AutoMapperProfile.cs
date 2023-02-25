using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rcs_p.Dtos;

namespace rcs_p
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Request,GetRequestResponseDto>();
            CreateMap<AddRequestPromptDto, Request>();
            /*CreateMap<UpdateRequestPromptDto, Request>();*/
        }
    }
}