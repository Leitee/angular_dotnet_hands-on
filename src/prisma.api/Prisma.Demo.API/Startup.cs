using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leonardo.Moreno.CORE.Base;
using Leonardo.Moreno.CORE.Contract.Data;
using Leonardo.Moreno.CORE.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Pandora.NetStandard.Data.Dals;
using Prisma.Demo.BUSINESS.Services;
using Prisma.Demo.DATA.Dals;

namespace Prisma.Demo.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCors();
            services.AddMvc()
                .AddJsonOptions(jop =>
                {
                    jop.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    jop.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    jop.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddApiVersioning(o => {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            // Add configuration for DbContext
            // Use connection string from appsettings.json file
            services.AddDbContext<PrismaDbContext>();

            services.AddScoped<ILogger, Logger<ApiBaseController>>();
            services.AddSingleton<IMapperCore, GenericMapperCore>();
            services.AddSingleton<RepositoryFactories<PrismaDbContext>>();
            services.AddScoped<IRepositoryProvider<PrismaDbContext>, RepositoryProvider<PrismaDbContext>>();
            services.AddScoped<IApplicationUow, ApplicationUow<PrismaDbContext>>();
            services.AddScoped<ICompetidorSvc, CompetidorSvc>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMvc();
        }
    }
}
