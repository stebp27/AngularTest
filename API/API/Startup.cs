using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.EF_DB_Layer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace API
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
            //ADDED TO ALLOW CORS ANY ORIGIN
            //https://stackoverflow.com/questions/31942037/how-to-enable-cors-in-asp-net-core
            services.AddCors(o => o.AddPolicy("Policy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //Add to use the DbContext; Can be used injection here? Always remember to put the options to the connection string
            services.AddDbContext<ApplicationDBContext>(option => option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibraryAPI;Integrated Security=True;MultipleActiveResultSets=true"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //ADDED TO ALLOW CORS ANY ORIGIN - always before app.UseMvc();
            //https://stackoverflow.com/questions/31942037/how-to-enable-cors-in-asp-net-core
            app.UseCors("Policy");
            app.UseMvc();
        }
    }
}
