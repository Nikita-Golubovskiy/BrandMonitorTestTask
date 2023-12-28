using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer.BrandMonitorTestTask.Cqrs.Commands;
using PresentationLayer.BrandMonitorTestTask.Rest.ApplicationStartup.Interfaces;
using PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Command.Canonical;
using PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Query.Parametric;
using PresentationLayer.BrandMonitorTestTask.Cqrs.Queries;

using CreateTaskCommandRequest = PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.CreateTask.Request;

using UpdateStateCommandRequest = PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.UpdateState.Request;

using GetTaskInformationQueryRequest = PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.GetTaskInformation.Request;
using GetTaskInformationQueryResponse = PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.GetTaskInformation.Response;

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
        servicesCollection.AddScoped<
            IAsyncQuery<GetTaskInformationQueryRequest, GetTaskInformationQueryResponse>,
            GetTaskInformation
        >();

        servicesCollection.AddScoped<IAsyncCommand<CreateTaskCommandRequest>, CreateTask>();
        servicesCollection.AddScoped<IAsyncCommand<UpdateStateCommandRequest>, UpdateState>();
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