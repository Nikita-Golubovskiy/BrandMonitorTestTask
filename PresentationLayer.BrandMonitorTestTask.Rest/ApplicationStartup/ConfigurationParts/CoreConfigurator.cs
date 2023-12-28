using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PresentationLayer.BrandMonitorTestTask.Rest.ApplicationStartup.Interfaces;
using SharedLayer.BrandMonitorTestTask.Extensions;

namespace PresentationLayer.BrandMonitorTestTask.Rest.ApplicationStartup.ConfigurationParts;

/// <summary>
/// ASP.NET Core configuration startup class.
/// </summary>
internal sealed class CoreConfigurator : IConfigurator
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="hostBuilder">Host builder, which ones must to be configured, reference value.</param>
    /// <param name="webHostingEnvironment">Web hosting environment information provider reference value.</param>
    public CoreConfigurator(IHostBuilder hostBuilder, IWebHostEnvironment webHostingEnvironment)
    {
        hostBuilder.UseDefaultServiceProvider(serviceProviderOptions =>
        {
            serviceProviderOptions.ValidateScopes = webHostingEnvironment.IsDebug();
        });
    }

    /// <summary>
    /// Services collection setup/configuring method.
    /// </summary>
    /// <param name="servicesCollection">Services collection, which ones must to be configured, reference value.</param>
    public void ConfigureServices(IServiceCollection servicesCollection)
    {
    }

    /// <summary>
    /// Global application building method.
    /// </summary>
    /// <param name="applicationBuilder">Application request pipeline builder reference value.</param>
    /// <param name="webHostingEnvironment">Web hosting environment information provider reference value.</param>
    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostingEnvironment)
    {
        if (webHostingEnvironment.IsDebug())
        {
            applicationBuilder.UseDeveloperExceptionPage();
        }

        applicationBuilder.UseHttpsRedirection();

        applicationBuilder.UseRouting();

        applicationBuilder.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}