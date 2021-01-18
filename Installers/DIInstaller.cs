using HumanResource.Api.Helpers;
using HumanResource.ApplicationCore.Interfaces;
using HumanResource.Infrastructure.Data;
using HumanResource.Infrastructure.Services;
using IThong.Interfaces;
using IThong.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Api.Installers
{
    public class DIInstaller : IInstaller

    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //
            services.AddSingleton(new Cryptography());

            //repositories



            //services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRoleService,RoleService>();
            services.AddScoped<ILawService, LawService>();
            services.AddScoped<IVehicleTypeService, VehicleTypeService>();
            services.AddScoped<IDriversLicensesTypeService, DriversLicensesTypeService>();
            services.AddScoped<IRecordProfileService, RecordProfileService>();
            services.AddScoped<ICitizenShipProfileService, CitizenShipProfileService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IMarginalSanctionsTableService, MarginalSanctionsTableService>();
        }
    }
}
