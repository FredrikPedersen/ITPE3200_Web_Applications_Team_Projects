using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vy_TicketPurchase_Core.Business;
using Vy_TicketPurchase_Core.Business.Departures;
using Vy_TicketPurchase_Core.Business.PassengerType;
using Vy_TicketPurchase_Core.Business.Stations;
using Vy_TicketPurchase_Core.Business.Tickets;
using Vy_TicketPurchase_Core.Business.Users;
using Vy_TicketPurchase_Core.Repository;

namespace Vy_TicketPurchase_Core
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

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
                {
                    options.IdleTimeout = TimeSpan.FromSeconds(10);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                }
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            var connection = @"Server=(localdb)\mssqllocaldb;Database=TicketDatabase;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
            services.AddScoped<StationService>();
            services.AddScoped<TicketService>();
            services.AddScoped<DepartureService>();
            services.AddScoped<UserService>();
            services.AddScoped<PassengerTypeService>();
            services.AddMvc();
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();
            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Vy}/{action=Index}/{id?}");
            });

            InitializeMigrations(app);
        }

        private static void InitializeMigrations(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                DbInit.Initialize(serviceScope);
            }
        }
    }
}