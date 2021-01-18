using HR.Helpers;
using HumanResource.Api.Installers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Installers
{
    public class AuthorizationInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(option => option.AddPolicy(Constant.RolePolicy.NHANVIEN, policy => policy.RequireClaim(Constant.CustomClaims.ROLE, "1")));
            services.AddAuthorization(option => option.AddPolicy(Constant.RolePolicy.CANBO, poliecy => poliecy.RequireClaim(Constant.CustomClaims.ROLE, "2")));
            services.AddAuthorization(option => option.AddPolicy(Constant.RolePolicy.NGUOIDUNG, poliecy => poliecy.RequireClaim(Constant.CustomClaims.ROLE, "3")));
        }
    }
}
