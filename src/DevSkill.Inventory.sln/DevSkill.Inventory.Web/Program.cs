using Autofac;
using Autofac.Extensions.DependencyInjection;
using DevSkill.Inventory.Application.Features.Products.Commands;
using DevSkill.Inventory.Infrastructure;
using DevSkill.Inventory.Infrastructure.Identity;
using DevSkill.Inventory.Web;
using DevSkill.Inventory.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Configuration;
using System.Reflection;
using DevSkill.Inventory.Infrastructure.Extensions;

var configuration = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile("appsettings.json") 
      .Build();  


Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateBootstrapLogger();
try
{
    Log.Information("Application Starting...17-jan");
    Log.Information("This is Nasim Reza Hridoy");
    Log.Debug("Debug level log for testing");
    Log.Error("An error occurred while starting the application.");

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    var migrationAssembly = Assembly.GetExecutingAssembly();

    #region Serilog Configuration
    builder.Services.AddLogging(loggingBuilder =>
    loggingBuilder.AddSerilog(dispose: true));
    #endregion

    #region Autofac Configuration
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(ContainerBuilder =>
    {
        ContainerBuilder.RegisterModule(new WebModule(connectionString, migrationAssembly?.FullName));
    });
    #endregion

    #region MediatR Configuration
    builder.Services.AddMediatR(cfg => { 
        cfg.RegisterServicesFromAssembly(migrationAssembly);
        cfg.RegisterServicesFromAssembly(typeof(ProductAddCommand).Assembly);
    });
    #endregion

    #region Auto Mapper Configuration
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    #endregion

    #region Identity Configuration
    builder.Services.AddIdentity();
    #endregion



    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString, (x) => x.MigrationsAssembly(migrationAssembly)));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();





    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();
   



    builder.Host.UseSerilog((context, lc) => lc
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(builder.Configuration)
        .WriteTo.Console()
        //.WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Day)
       

    );






    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthorization();

    app.MapStaticAssets();



    app.MapControllerRoute(
       name: "areas",
       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
       .WithStaticAssets();


    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.MapRazorPages()
       .WithStaticAssets();
   // app.UseSerilogRequestLogging();

    app.Run();
}

catch(Exception ex)
{
    Log.Fatal(ex, "Application crashed");
}
finally
{
    Log.CloseAndFlush();
}