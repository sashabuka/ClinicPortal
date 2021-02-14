using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicPortal.Domain.Search;
using ClinicPortal.Domain.Service;
using ClinicPortal.Entity;
using ClinicPortal.Entity.Convertor;
using ClinicPortal.Entity.Search;
using ClinicPortal.Entity.Search.Result;
using ClinicPortal.Entity.Search.Result.Details;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClinicPortal
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
            services.AddControllersWithViews();
            ConfigureIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Search}/{action=Index}/{id?}");
            });
        }

        private void ConfigureIoC(IServiceCollection services)
        {
            string baseUrl = Configuration.GetValue<string>("BaseUrl");

            //services.AddScoped(provider => new CustomerPortalDbContext(connectionString));
            services.AddTransient<IClinicApiConvertor<DetailsResult>, DetailsResultConvertor>();
            services.AddTransient<IClinicApiConvertor<IEnumerable<SearchResult>>, SearchResultConvertor>();

            services.AddTransient<IClinicSearchable>(provider =>
                new ClinicHttpClient(baseUrl,
                    provider.GetService<IClinicApiConvertor<IEnumerable<SearchResult>>>(),
                    provider.GetService<IClinicApiConvertor<DetailsResult>>()));

            services.AddScoped<ISearchService, ClinicSearchService>();
        }
    }
}
