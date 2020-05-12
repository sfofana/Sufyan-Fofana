using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JS.Fofana_Bank_V2._3_Backend.Configurations;
using JS.Fofana_Bank_V2._3_Backend.Contexts;
using JS.Fofana_Bank_V2._3_Backend.Exceptions;
using JS.Fofana_Bank_V2._3_Backend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace JS.Fofana_Bank_V2._3_Backend
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
            services.Configure<Settings>(Configuration.GetSection("Settings"));
            services.AddAuthentication("Basic-Auth")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>("Basic-Auth", null);
            services.AddControllers();
            services.AddScoped<IUserService, UserService>();
            services.AddDbContextPool<UserContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("Embedded"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.ConfigureExceptionHandler();
            app.ConfigureExceptionMiddleware();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
