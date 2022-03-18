using MegaKit.BLL.Abstract;
using MegaKit.BLL.Concrate;
using MegaKit.DAL.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MegaKit.EL.DBConnection;

namespace MegaKit.API
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
            EL.DBConnection.SQLServer.Title = "SQL Server MegaKit";
            EL.DBConnection.SQLServer.ConnectionString = Configuration.GetConnectionString("SQLServer");

            //AddDbContext metodu yazılması gerek.
            services.AddDbContext<ContextMegaKit>(options => options.UseSqlServer(SQLServer.ConnectionString, b => b.MigrationsAssembly("MegaKit.DAL")));

            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IAboutRepository, AboutRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MegaKit.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MegaKit.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
