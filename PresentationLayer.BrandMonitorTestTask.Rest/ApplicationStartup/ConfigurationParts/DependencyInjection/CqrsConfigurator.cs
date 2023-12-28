using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer.BrandMonitorTestTask.Rest.ApplicationStartup.Interfaces;

namespace PresentationLayer.BrandMonitorTestTask.Rest.ApplicationStartup.ConfigurationParts.DependencyInjection;

/// <summary>
/// CQRS DI configuration startup class.
/// </summary>
internal sealed class CqrsConfigurator : IConfigurator
{
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
    }
}