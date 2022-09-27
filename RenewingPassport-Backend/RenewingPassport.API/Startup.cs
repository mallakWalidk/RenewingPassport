using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RenewingPassport.Core.Common;
using RenewingPassport.Core.Repository;
using RenewingPassport.Core.Service;
using RenewingPassport.Infra.Common;
using RenewingPassport.Infra.Repository;
using RenewingPassport.Infra.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenewingPassport.API
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
            services.AddCors(corsOptions =>

            {

                corsOptions.AddPolicy("policy",

                builder =>

                {

                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                });

            });
            services.AddControllers();

            services.AddScoped<IDbContext, DbContext>();

            // Repository
            services.AddScoped<IAboutUsRepository, AboutUsRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IContactInfoRepository, ContactInfoRepository>();
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IFeedBackRepository, FeedBackRepository>();
            services.AddScoped<IHomepageRepository, HomepageRepository>();
            services.AddScoped<IPassportRepository, PassportRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWebsiteRepository, WebsiteRepository>();
            services.AddScoped<IChartRepository, ChartRepository>();
            services.AddScoped<IJwtRepository, JwtRepository>();
            //Service
            services.AddScoped<IAboutUsService, AboutUsService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IContactInfoService, ContactInfoService>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<IFeedBackService, FeedBackService>();
            services.AddScoped<IHomepageService, HomepageService>();
            services.AddScoped<IPassportService, PassportService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITestimonialService, TestimonialService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWebsiteService, WebsiteService>();
            services.AddScoped<IChartService, ChartService>();
            services.AddScoped<IJwtService, JwtService>();

            //Authentication
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(y =>
            {
                y.RequireHttpsMetadata = false;
                y.SaveToken = true;
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("RenewingPassport Private key")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("policy");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
