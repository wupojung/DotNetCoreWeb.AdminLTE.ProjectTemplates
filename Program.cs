using Asp.Versioning;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DotNetCoreWeb.AdminLTE.ProjectTemplates.Core;
using DotNetCoreWeb.AdminLTE.ProjectTemplates.Services.User;

namespace DotNetCoreWeb.AdminLTE.ProjectTemplates;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // 啟動Autofac IoC框架
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(_builder =>
            _builder.RegisterModule(new AutofacModuleRegister()));

        // Add services to the container.
        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
     
        // Add api versioning
        builder.Services.AddApiVersioning(
                options =>
                {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(2.0);
                })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;

                //options.AssumeDefaultVersionWhenUnspecified = true;
                //options.DefaultApiVersion = new ApiVersion(2.0);
            });


        // Setup Database 
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        builder.Services.AddDbContext<SqlContext>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication(); // first then UseAuthorization
        app.UseAuthorization();

        #region Map All Controller Route

        app.MapAreaControllerRoute(
            name: "admin",
            areaName: "Admin",
            pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        #endregion

        app.Run();
    }
}