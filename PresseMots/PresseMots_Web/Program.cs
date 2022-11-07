using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PresseMots_DataAccess.Context;
using PresseMots_Utility;
using System.Collections.Generic;
using System.Globalization;
using Vereyon.Web;

var supportedCultures = new List<CultureInfo>() { new CultureInfo("en-US"), new CultureInfo("fr-CA") };


var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
var services = builder.Services;

services.AddLocalization(options=>options.ResourcesPath="Resources");
services.AddControllersWithViews()
    .AddMvcLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();



services.AddDbContext<PresseMotsDbContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("PresseMotsWebCS"));
    opt.UseLazyLoadingProxies();


});
services.AddSingleton<WordCounter>();
services.AddScoped((a) =>
{
    HtmlSanitizer sanitizer = HtmlSanitizer.SimpleHtml5Sanitizer();
    sanitizer.SanitizeCssClasses = false;
    return sanitizer;

});


services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US","en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;


});

var app = builder.Build();
var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

public partial class Program { }