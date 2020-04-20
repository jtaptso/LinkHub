using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LHBLL;
using LHBOL;
using LHDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LHUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            #region BLL Services
            services.AddTransient<ICategoryBs, CategoryBs>();
            services.AddTransient<ILHUrlBs, LHUrlBs>();
            services.AddTransient<ILHUserBs, LHUserBs>();
            #endregion

            #region DAL Services
            services.AddTransient<ICategoryDb, CategoryDb>();
            services.AddTransient<ILHUrlDb, LHUrlDb>();
            services.AddTransient<ILHUserDb, LHUserDb>(); 
            #endregion

            services.AddDbContext<LHDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LHConnection")));

            services.AddIdentity<LHUser, IdentityRole>()
                .AddEntityFrameworkStores<LHDbContext>()
                .AddDefaultTokenProviders();

            var policy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser()
                                    .Build();
            services.AddMvc(x => x.Filters.Add(new AuthorizeFilter(policy)));
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Categories}/{action=Index}/{id?}");
            });
        }
    }
}
