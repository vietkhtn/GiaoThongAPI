using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Api.DTOS.Responses
{
    public class AuthResponseSuccess: AuthResult
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
