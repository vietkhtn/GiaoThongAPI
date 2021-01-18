using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Api.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddSwaggerGen(x =>
            {
                var security = new OpenApiSecurityRequirement{
                          {
                             new OpenApiSecurityScheme{
                                 Reference = new OpenApiReference{
                                 Id = "Bearer", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                          },new List<string>()  }};
                x.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                x.AddSecurityRequirement(security);
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "HR.Api", Version = "v1" });
                //x.ExampleFilters();
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //x.IncludeXmlComments(xmlPath);
            });
       //     services.AddSwaggerExamplesFromAssemblyOf<Startup>();

        }
    }
}
