using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace PresentationLayer.BrandMonitorTestTask.Rest.ApplicationStartup.Interfaces;

/// <summary>
/// Application configuration/startup interface.
/// </summary>
internal interface IConfigurator
{
    /// <summary>
    /// Services collection setup/configuring method.
    /// </summary>
    /// <param name="servicesCollection">Services collection, which ones must to be configured, reference value.</param>
    void ConfigureServices(IServiceCollection servicesCollection);

    /// <summary>
    /// Global application building method.
    /// </summary>
    /// <param name="applicationBuilder">Application request pipeline builder reference value.</param>
    /// <param name="webHostingEnvironment">Web hosting environment information provider reference value.</param>
    void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostingEnvironment);
}