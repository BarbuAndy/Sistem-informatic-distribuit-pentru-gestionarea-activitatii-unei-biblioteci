using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.context;
using WebApplication.Repositories;
using WebApplication.Services;

namespace WebApplication
{
    public class Startup
    {
        public IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // services.AddDbContext<LibraryDb>(options => options.UseSqlServer(connectionString: @"Data Source=(local)\SQLEXPRESS;User ID=Project2;Password=Project2;"));

            services.AddDbContext<LibraryDb>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
            services.AddControllersWithViews(); //.AddRazorRuntimeCompilation();


            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<BookService>();
            services.AddScoped<AuthorService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Index}/{action=Index}/{id?}");
            });
        }
    }
}
