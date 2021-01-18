using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IThong.Extentions
{
    public static class GeneralExtensions
    {
        public static string GetClaim(this HttpContext httpContext, string claim)
        {
            if (httpContext.User == null)
            {
                return string.Empty;
            }
            return httpContext.User.Claims.SingleOrDefault(x => x.Type == claim).Value;
        }
    }
}
