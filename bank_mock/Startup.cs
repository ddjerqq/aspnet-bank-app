using bank_mock.Core.Contexts;
using bank_mock.Core.Models;
using bank_mock.Core.Repositories;
using bank_mock.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace bank_mock
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "bank_mock", Version = "v1"});
            });

            services.AddRouting(ro => ro.LowercaseUrls = true);

            services.AddDbContext<UserContext>(oa =>
                {
                    oa.UseInMemoryDatabase("bank_mock");
                }
            );
            
            // TODO es sworia?? tu IDataRepository<User>?
            // TODO                                                       amas DataRepository rato qvia
            //services.AddScoped(typeof(IDataRepository<>), typeof(DataRepository<>));
            // TODO aq rato aris interface, da mere inheritori?
            services.AddScoped<IDataRepository<User>, UserReository>();

            
            // TODO es cudia? ase ar unda iyos wesit?
            // microsoft docs qonda ro Interfaceis tipis servici iyos implementorze
            // services.AddScoped(typeof(AccountRepository), typeof(AccountRepository));
            services.AddScoped<IDataRepository<Account>, AccountRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "bank_mock v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}