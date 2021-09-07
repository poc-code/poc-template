using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Poc_Template_Api.Extensions;
using Poc_Template_Api.Filters;
using Poc_Template_Api.Middlewares;
using System.Diagnostics.CodeAnalysis;

namespace Poc_Template_Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(config =>
            {
                config.Filters.Add<DomainNotificationFilter>();
                config.EnableEndpointRouting = false;
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            }); 

            services.AddHttpClients(Configuration);
            services.ConfigureIoC(Configuration);
            services.AddAutoMapper(typeof(Startup));

            services.AddResponseCompression(x =>
            {
                x.Providers.Add<GzipCompressionProvider>();
            });

            services.AddHealthcheckConfigurations(Configuration);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Poc-Template-RestApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Poc_Template v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseResponseCompression();
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new ErrorHandlerMiddleware(env).Invoke
            });
            app.UseMiddleware<ResponseTimeMiddleware>();
            

            app.UseCors(builder => builder
             .SetIsOriginAllowedToAllowWildcardSubdomains()
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                //.AllowCredentials()
              );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                if (PlatformServices.Default.Application.ApplicationName != "testhost")
                {
                    //Para cada sistema de terceiro ou API da Wiz (incluir URL em appsettings.json)
                    //endpoints.MapHealthChecks("{sistema}", ...);
                    endpoints.MapHealthChecks("/health", new HealthCheckOptions
                    {
                        Predicate = r => r.Tags.Contains("self"),
                        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                    });
                    endpoints.MapHealthChecks("/ready", new HealthCheckOptions
                    {
                        Predicate = r => r.Tags.Contains("services"),
                        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                    });
                    endpoints.MapHealthChecksUI(setup =>
                    {
                        setup.UIPath = "/health-ui";
                    });
                }
                endpoints.MapControllers();
            });
        }
    }
}
