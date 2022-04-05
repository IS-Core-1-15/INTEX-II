using INTEX_II.Data;
using INTEX_II.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX_II
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
            services.AddDbContext<CrashContext>(options =>
            {
                options.UseMySql(Environment.GetEnvironmentVariable("CrashConnection"));
            });

            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseMySql(Environment.GetEnvironmentVariable("IdentityConnection"));
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // changed from default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 12;
                options.Password.RequiredUniqueChars = 5;
            });

            services.AddControllersWithViews();
            
            services.AddRazorPages();

            services.AddScoped<ICrashRepository, EFCrashRepository>();

            services.AddDistributedMemoryCache();

            services.AddSession();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddServerSideBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute("countypage", "{countyName}/Page-{pageNum}", new { Controller = "Home", action = "SummaryInformation" });

                //endpoints.MapControllerRoute("Paging", "Page-{pageNum}", new { Controller = "Home", action = "SummaryInformation" , pageNum = 1});

                //endpoints.MapControllerRoute("county", "{countyName}", new { Controller = "Home", action = "SummaryInformation" });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();

                //endpoints.MapBlazorHub();

                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "{controller=Admin}/{action=Main}/{pageNum?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
