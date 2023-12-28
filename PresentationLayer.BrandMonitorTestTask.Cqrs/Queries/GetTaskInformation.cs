using System.Threading.Tasks;
using BusinessLogicLayer.BrandMonitorTestTask.Repository.Interfaces;
using PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.GetTaskInformation;
using PresentationLayer.BrandMonitorTestTask.Cqrs.Exceptions;
using PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Query.Parametric;

using Errors = PresentationLayer.BrandMonitorTestTask.Cqrs.Assets.Strings.Errors.Common;

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.Queries;

/// <summary>
/// Task information providing query class.
/// </summary>
public sealed class GetTaskInformation : IAsyncQuery<Request, Response>
{
    /// <summary>
    /// Tasks repository DI reference field.
    /// </summary>
    private readonly ITasksRepository tasksRepository;

    /// <summary>
    /// Main constructor.
    /// </summary>
    /// <param name="tasksRepository">Tasks repository reference value, obtaining from DI.</param>
    public GetTaskInformation(ITasksRepository tasksRepository)
    {
        this.tasksRepository = tasksRepository;
    }

    /// <summary>
    /// Query handling/execution method.
    /// </summary>
    /// <param name="request">Request data describing/containing object reference value.</param>
    /// <returns>Result data describing/containing object value.</returns>
    public async Task<Response> Execute(Request request)
    {
        if (request is null)
        {
            throw new CqrsException(Errors.REQUEST_ARGUMENT_IS_MISSING);
        }

        if (!await this.tasksRepository.IsExist(request.ID))
        {
            return new Response(null, null, false);
        }

        var taskInformation = await this.tasksRepository.GetTaskInformation(request.ID);

        var converter = new Converters.GetTaskInformation.Converter();

        return converter.Convert(taskInformation);
    }
}