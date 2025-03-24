using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ServerApi.Data;
using ServerApi.Services;
using System.IO;

namespace ServerApi;
public class Startup
{
    public IConfiguration Configuration { get; }
    public static string ConnectionString { get; private set; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        /*         ConnectionString= Configuration.GetConnectionString("connectionString");
                Configuration["started"] =DateTime.Now.ToString(); */

    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("connectionString")));
        services.AddControllersWithViews();
        services.AddScoped<IBlogService, BlogService>();
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.Use(async (context, next) =>
        {
            await next();
            if (context.Response.StatusCode == 404 && !System.IO.Path.HasExtension(context.Request.Path.Value))
            {
                context.Request.Path = "/index.html";
                await next();
            }
        });
        app.UseDefaultFiles();


        app.UseCors(); // Enable CORS for all requests 
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}