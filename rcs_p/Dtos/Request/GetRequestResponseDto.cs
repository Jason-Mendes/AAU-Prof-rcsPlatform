using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rcs_p.Dtos.Request
{
    public class GetRequestResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; internal set; }
        public string Send { get; set; } = "Send";
        public Requests clas { get; set; } = Requests.Send;
    }
}