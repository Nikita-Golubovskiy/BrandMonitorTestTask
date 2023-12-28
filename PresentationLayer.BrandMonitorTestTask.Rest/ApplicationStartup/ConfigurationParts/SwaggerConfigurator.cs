using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PresentationLayer.BrandMonitorTestTask.Rest.ApplicationStartup.Interfaces;
using SharedLayer.BrandMonitorTestTask.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PresentationLayer.BrandMonitorTestTask.Rest.ApplicationStartup.ConfigurationParts;

/// <summary>
/// Swagger configuration startup class.
/// </summary>
internal sealed class SwaggerConfigurator : IConfigurator
{
    /// <summary>
    /// Services collection setup/configuring method.
    /// </summary>
    /// <param name="servicesCollection">Services collection, which ones must to be configured, reference value.</param>
    public void ConfigureServices(IServiceCollection servicesCollection)
    {
        servicesCollection
            .AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PresentationLayer.BrandMonitorTestTask.Rest",
                    Version = "v1"
                });

                options.MapType<decimal>(() => new OpenApiSchema
                {
                    Type = "number",
                    Format = "decimal"
                });

                options.CustomSchemaIds(type => type
                    .ToString()
                    .Replace("+", "::")
                );

                options.CustomOperationIds(apiDescription =>
                    apiDescription.TryGetMethodInfo(out var methodInfo) ? methodInfo.Name : null
                );

                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                options.UseAllOfToExtendReferenceSchemas();
            });
    }

    /// <summary>
    /// Global application building method.
    /// </summary>
    /// <param name="applicationBuilder">Application request pipeline builder reference value.</param>
    /// <param name="webHostingEnvironment">Web hosting environment information provider reference value.</param>
    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostingEnvironment)
    {
        // ReSharper disable once InvertIf
        if (webHostingEnvironment.IsDebug())
        {
            applicationBuilder.UseSwagger();

            applicationBuilder.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "BrandMonitorTestTask API v1");
            });
        }
    }
}