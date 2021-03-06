using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Project.Stock.Manager.Application.Data;
using Project.Stock.Manager.Application.Data.Repository;
using Project.Stock.Manager.Application.Services;
using Project.Stock.Manager.Infrastructure.Data;
using Project.Stock.Manager.Infrastructure.Data.Repository;

namespace Project.Stock.Manager
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
            services.AddDbContext<ApplicationContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Stock Manager", Version = "v1" });
            });

            ConfigureData(services);
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBatchService, BatchService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<ILoginAccountService, LoginAccountService>();
            services.AddScoped<ISellService, SellService>();
            services.AddScoped<ICustomerService, CustomerService>();
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

            //app.UseSwagger();

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend Application");
            //    c.RoutePrefix = string.Empty;
            //});

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=LoginAccount}/{action=Login}/{id?}");
            });
        }

        public static void ConfigureData(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBatchRepository, BatchRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<ISellRepository, SellRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
