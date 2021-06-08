using System;
using Employee.API.Provider.Contracts;
using Employee.DataAccessLayer.DBContexts;
using Employee.DataAccessLayer.Repositories;
using Employee.Provider;
using Employee.Provider.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Employee.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                              builder =>
                              {
                                  builder.WithOrigins("http://example.com",
                                                      "http://www.contoso.com").AllowAnyHeader()
                                .AllowAnyMethod();
                              });
        });
            services.AddControllers();

            services.AddScoped<IEmployeeProvider, EmployeeProvider>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<ITaskProvider, TaskProvider>();
            services.AddScoped<ITaskRepository, TaskRepository>();

            services.(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });
            services.AddDbContext<EmployeeContext>(options =>
            {              
                //var server = Configuration["ServerName"];
                //var port = "1433";
                //var database = Configuration["Database"];
                //var user = Configuration["UserName"];
                //var password = Configuration["Password"];

                //Console.WriteLine("Server is " + server);
                //Console.WriteLine("Database is " + database);
                //Console.WriteLine("Username is " + user);
                //Console.WriteLine("Password is " + password);
                
                
                //options.UseSqlServer(
                //    $"Server={server},{port};Initial Catalog={database};User ID={user};Password={password}",
                //    sqlServer => sqlServer.MigrationsAssembly("Employee.API"));
                options.UseSqlServer(@"Server=LAPTOP-OLL6HKD6\SQLEXPRESS;Database=Employee;Trusted_Connection=true");
               
            }); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        

        }
    }
}
