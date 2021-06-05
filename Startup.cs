using KissLog.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SGIEscolar.Data.AutoMapping;
using SGIEscolar.Data.Config;
using SGIEscolar.Data.Context;
using System;

namespace SGIEscolar
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddDbContext<SGIEscolarContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.DIREsolveDependences();
            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
                options.LoginPath = new PathString("/Login/Index");
                options.AccessDeniedPath = new PathString("/Login/Index");
                options.LogoutPath = new PathString("/Login/Index");
                options.ReturnUrlParameter = "";
            });
            services.AddMvcConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider provider)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/error/500");
                app.UseStatusCodePagesWithRedirects("/error/{0}");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UserGlobalizationConfig();
            
            app.UseKissLogMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
            LogConfig.RegisterKissLogListeners(Configuration);
        }
    }
}
