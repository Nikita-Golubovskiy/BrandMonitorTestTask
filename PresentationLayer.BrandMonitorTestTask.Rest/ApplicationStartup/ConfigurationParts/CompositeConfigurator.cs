using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer.BrandMonitorTestTask.Rest.ApplicationStartup.Interfaces;

namespace PresentationLayer.BrandMonitorTestTask.Rest.ApplicationStartup.ConfigurationParts;

/// <summary>
/// Composite configurator class.
/// </summary>
internal class CompositeConfigurator : IConfigurator
{
    /// <summary>
    /// Atomic configurators collection reference field.
    /// </summary>
    private readonly IConfigurator[] configurators;

    /// <summary>
    /// Services collection setup/configuring method.
    /// </summary>
    /// <param name="servicesCollection">Services collection, which ones must to be configured, reference value.</param>
    public void ConfigureServices(IServiceCollection servicesCollection)
    {
        foreach (var configurator in this.configurators)
        {
            configurator.ConfigureServices(servicesCollection);
        }
    }

    /// <summary>
    /// Global application building method.
    /// </summary>
    /// <param name="applicationBuilder">Application request pipeline builder reference value.</param>
    /// <param name="webHostingEnvironment">Web hosting environment information provider reference value.</param>
    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostingEnvironment)
    {
        foreach (var configurator in this.configurators)
        {
            configurator.Configure(applicationBuilder, webHostingEnvironment);
        }
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="configurators">Atomic configurators collection reference value.</param>
    public CompositeConfigurator(params IConfigurator[] configurators)
    {
        this.configurators = configurators;
    }
}