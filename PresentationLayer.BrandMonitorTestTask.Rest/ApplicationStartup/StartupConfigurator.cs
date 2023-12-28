using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer.BrandMonitorTestTask.Rest.ApplicationStartup.ConfigurationParts;
using PresentationLayer.BrandMonitorTestTask.Rest.ApplicationStartup.ConfigurationParts.DependencyInjection;
using PresentationLayer.BrandMonitorTestTask.Rest.ApplicationStartup.Interfaces;

namespace PresentationLayer.BrandMonitorTestTask.Rest.ApplicationStartup;

/// <summary>
/// Main/global application startup configuration class.<br />
/// N.B.: mostly known as Startup.cs.
/// </summary>
internal sealed class StartupConfigurator : IConfigurator
{
    /// <summary>
    /// Sub-configurator reference field.
    /// </summary>
    private readonly IConfigurator configurator;

    /// <summary>
    /// Main constructor.
    /// </summary>
    /// <param name="webApplicationBuilder">Web application builder, which ones must to be configured, reference value.</param>
    public StartupConfigurator(WebApplicationBuilder webApplicationBuilder)
    {
        this.configurator = new CompositeConfigurator(
            new VersioningApiConfigurator(),
            new SwaggerConfigurator(),
            new CoreConfigurator(webApplicationBuilder.Host, webApplicationBuilder.Environment),
            new RepositoryConfigurator(),
            new CqrsConfigurator()
        );
    }

    /// <summary>
    /// Services collection setup/configuring method.
    /// </summary>
    /// <param name="servicesCollection">Services collection, which ones must to be configured, reference value.</param>
    public void ConfigureServices(IServiceCollection servicesCollection)
    {
        this.configurator.ConfigureServices(servicesCollection);
    }

    /// <summary>
    /// Global application building method.
    /// </summary>
    /// <param name="applicationBuilder">Application request pipeline builder reference value.</param>
    /// <param name="webHostingEnvironment">Web hosting environment information provider reference value.</param>
    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostingEnvironment)
    {
        this.configurator.Configure(applicationBuilder, webHostingEnvironment);
    }
}