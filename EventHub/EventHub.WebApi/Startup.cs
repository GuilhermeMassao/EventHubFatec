using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using EventHub.Application.Mapping;
using EventHub.Application.Services.UserApplication;
using EventHub.Infraestructure.Interfaces.Repository;
using EventHub.Infraestructure.Repository;
using EventHub.Domain;
using EventHub.Business.Business;
using EventHub.Infraestructure.Repository.BaseRepository;
using EventHub.Application.Services.EventApplication;

namespace EventHub.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var mapperConfig = AutoMapperConfig.Register();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "EventHub",
                    Description = "Management events and advertisement in social networks"
                });
            });

            //IoC configuration
            /* WebAPI */

            /* Application */
            services.AddScoped<UserApplication>();
            services.AddScoped<EventApplication>();
            services.AddSingleton(mapperConfig.CreateMapper());

            /* Domain */
            services.AddScoped<EventHubEntities>();

            /* Insfrastructure */
            services.AddScoped<IRepository<User>, UserRepository>();

            /* Business */
            services.AddScoped<UserBusiness>();
            services.AddScoped<EventBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            });


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
