using LsSocial_Backend.DAL;
using LsSocial_Backend.Managers;
using LsSocial_Backend.DbContent;
using LsSocial_Backend.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LsSocial_Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region Public Methods
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            AddScopes(services);
            AddCorsPolicy(services, "CorsPolicy");

            // Add DbContext
            services.AddDbContext<LaSocialContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LaSocialContext")));

            // Camle Cast Handle.
            services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        #endregion

        #region Private Methods
        private void AddCorsPolicy(IServiceCollection services, string name)
        {
            services.AddCors(o => o.AddPolicy(name, builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
        }

        private void AddScopes(IServiceCollection services)
        {
            services.AddScoped<IPostsDal, PostsDal>();
            services.AddScoped<IPostsManager, PostsManager>();

            services.AddScoped<ISignupDal, SignupDal>();
            services.AddScoped<ISignupManager, SignupManager>();

            services.AddScoped<ILoginDal, LoginDal>();
            services.AddScoped<ILoginManager, LoginManager>();

            services.AddScoped<IAuthenticationHelper, AuthenticationHelper>();
        }
        #endregion
    }
}