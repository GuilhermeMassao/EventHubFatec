using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using EventHub.Application.Mapping;
using EventHub.Application.Services.UserApplication;
using EventHub.Infraestructure.Repository;
using EventHub.Business.Business;
using EventHub.Domain.Entities;
using EventHub.Infrastructure.Interfaces.Repository;
using EventHub.Application.Services.SocialApplication;
using EventHub.Application.Services.EventApplication;
using EventHub.Infrastructure.Repositories;

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
            services.AddScoped<SocialApplication>();
            services.AddScoped<EventApplication>();
            services.AddSingleton(mapperConfig.CreateMapper());

            /* Domain */

            /* Insfrastructure */
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IAdressRepository, AdressRepository>();
            services.AddScoped<IPublicPlaceRepository, PublicPlaceRepository>();
            services.AddScoped<ITwitterSocialMarketingRepository, TwitterSocialMarketingRepository>();
            services.AddScoped<IGoogleCalendarSocialMarketingRepository, GoogleCalendarSocialMarketingRepository>();

            /* Business */
            services.AddScoped<UserBusiness>();
            services.AddScoped<SocialBusiness>();
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
