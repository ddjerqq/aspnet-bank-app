using bank_mock.Core.Contexts;
using bank_mock.Core.Models;
using bank_mock.Core.Profiles;
using bank_mock.Core.Repositories;
using bank_mock.Core.Repositories.Interfaces;
using bank_mock.Core.Services;
using bank_mock.Core.Services.Interfaces;
using bank_mock.Core.Validators;
using bank_mock.Filters;
using FluentValidation.AspNetCore;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));
            
            services.AddMvc(o => 
                    o.Filters.Add(typeof(ModelStateValidator)))
                .AddFluentValidation(x =>
                    x.RegisterValidatorsFromAssemblyContaining<AccountValidator>());
            
            services.AddControllers();
            
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "bank_mock", Version = "v1"}));
            
            services.AddRouting(o => o.LowercaseUrls = true);
            
            // databases
            services.AddDbContext<ApplicationDatabaseContext>(o =>
                o.UseInMemoryDatabase("bank_mock"));
            
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService,    AccountService>();
            services.AddScoped<IUserRepository,    UserRepository>();
            services.AddScoped<IUserService,       UserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseDeveloperExceptionPage();
            
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "bank_mock v1"));

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
