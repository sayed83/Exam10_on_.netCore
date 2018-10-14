using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact10.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contact10
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration Config)
        {
            Configuration = Config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ContactDBContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ContactDBContext>().AddDefaultTokenProviders();
            //services.ConfigureApplicationCookie(option =>
            //{
            //    option.LoginPath = "/Contact/Login";
            //    option.Cookie.HttpOnly = true;
            //    option.ExpireTimeSpan = TimeSpan.FromHours(1);
            //});
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseAuthentication();
            //app.UseStaticFiles();
            //CreateUserandRole(service).Wait();
            app.UseMvc(route =>
            {
                route.MapRoute(
                    name: "Default",
                    template: "{controller=Contact}/{action=Index}/{id?}"

                    );
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
        //public async Task CreateUserandRole(IServiceProvider service)
        //{
        //    var userManager = service.GetRequiredService<UserManager<IdentityUser>>();
        //    var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
        //    var user = new IdentityUser
        //    {
        //        UserName = "a@a.com",
        //        Email = "a@a.com"
        //    };
        //    await userManager.CreateAsync(user, "@Test123");
        //    await roleManager.CreateAsync(new IdentityRole { Name = "admin" });
        //    await userManager.AddToRoleAsync(user, "admin");



       // }
    }
}
