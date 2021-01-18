using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Api.DTOS.Responses
{
    public class AuthResponseFail:AuthResult
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
