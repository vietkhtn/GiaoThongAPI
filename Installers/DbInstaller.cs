using HumanResource.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Api.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DataContext>(builder =>
            {
                builder.UseMySql(
                    configuration.GetConnectionString("ConnectionMysqlAzure"),
                    options =>
                    {
                        options.EnableRetryOnFailure();
                    });
            });
        }
    }
}
