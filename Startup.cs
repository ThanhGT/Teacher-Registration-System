using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tran_Thanh_991515427_Exam.Models;

namespace Tran_Thanh_991515427_Exam
{
    public class Startup
    {
        //load configuration settings in the appsettings.json file and make them available through a property called configuration
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        private IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            //sets up the shared objects required by application using the MVC framework and the razor view engine
            services.AddControllersWithViews();
            // Entity Core Framework is configured with the AddDBContext method, which registers the database context class
            // and configures the relationship with the database using "UseSqlServer" method
            services.AddDbContext<MBS_DBContext>(opts =>
            {
                opts.UseSqlServer(Configuration["ConnectionStrings:MBSConnStr"]);
            });

            //creates service where each HTTP request gets its own repository object
            services.AddScoped<ITeacherRepository, EFSystemRepository>();
            //allows use of razor pages
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //method enables support for serving static content from the wwwrootfolder
                app.UseStaticFiles();
                //adds a simple message to HTTP responses that would not otherwise havea body (ex: 404-error pages)
                app.UseStatusCodePages();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //method is used to register the MVC framework as a source of endpoints
                endpoints.MapDefaultControllerRoute();
                //configure razor pages
                endpoints.MapRazorPages();
            });
            //ensure that there is some sample in the database
            SeedData.DataPopulated(app);
        }
    }
}
