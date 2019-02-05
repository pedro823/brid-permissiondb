using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using PermissionDB.Connectors;

namespace PermissionDB
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDatabaseConnector, DatabaseConnector>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Remember to use PGPASSFILE
            var postgresDbConnectionArgs = "INSERT PRODUCTION VALUES HERE";
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                postgresDbConnectionArgs = "Host=localhost;Port=5432;Username=permissiondb;password=bridbrid;";
            }

            var postgresDbConnection = new NpgsqlConnection(postgresDbConnectionArgs);
            postgresDbConnection.Open();
            DatabaseConnector.Initialize(postgresDbConnection);
            
            app.UseMvc();
        }
    }
}
