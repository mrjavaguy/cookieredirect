using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace identity
{
    public class AuthSchemes
    {
        public const string CookieAuthName = "CustomCookie";
    }
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = AuthSchemes.CookieAuthName;
                options.DefaultChallengeScheme = AuthSchemes.CookieAuthName;
                options.DefaultSignInScheme = AuthSchemes.CookieAuthName;
                options.DefaultSignOutScheme = AuthSchemes.CookieAuthName;
                options.DefaultAuthenticateScheme = AuthSchemes.CookieAuthName;
                options.DefaultForbidScheme = AuthSchemes.CookieAuthName;
            })
            .AddCookie(AuthSchemes.CookieAuthName);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
