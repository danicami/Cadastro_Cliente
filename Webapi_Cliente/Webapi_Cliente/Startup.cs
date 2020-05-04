using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webapi_Cliente.Domain.Entities;
using Webapi_Cliente.Domain.Interface;
using Webapi_Cliente.Infra.Data.Context;
using Webapi_Cliente.Infra.Data.Repository;
using Webapi_Cliente.Service.Services;

namespace Webapi_Cliente
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
            var connection = Configuration["ConexaoSql:SqlConnectionString"];
            services.AddDbContext<ApplicationContext>(options =>
                options.UseInMemoryDatabase (connection)
            );
            services.AddScoped<IService<Cliente>, BaseService<Cliente>>();
            services.AddScoped<IRepository<Cliente>, BaseRepository<Cliente>>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
