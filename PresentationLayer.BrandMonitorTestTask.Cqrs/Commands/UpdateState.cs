using System.Threading.Tasks;
using BusinessLogicLayer.BrandMonitorTestTask.Repository.Interfaces;
using PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.UpdateState;
using PresentationLayer.BrandMonitorTestTask.Cqrs.Exceptions;
using PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Command.Canonical;

using Errors = PresentationLayer.BrandMonitorTestTask.Cqrs.Assets.Strings.Errors.Common;

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.Commands;

/// <summary>
/// Task state updating command class.
/// </summary>
public sealed class UpdateState : IAsyncCommand<Request>
{
    /// <summary>
    /// Tasks repository DI reference field.
    /// </summary>
    private readonly ITasksRepository tasksRepository;

    /// <summary>
    /// Main constructor.
    /// </summary>
    /// <param name="tasksRepository">Tasks repository reference value, obtaining from DI.</param>
    public UpdateState(ITasksRepository tasksRepository)
    {
        this.tasksRepository = tasksRepository;
    }

    /// <summary>
    /// Command handling/execution method.
    /// </summary>
    /// <param name="request">Request data describing/containing object reference value.</param>
    /// <returns>Result data describing/containing object value.</returns>
    public async Task Execute(Request request)
    {
        if (request is null)
        {
            throw new CqrsException(Errors.REQUEST_ARGUMENT_IS_MISSING);
        }

        if (!await this.tasksRepository.IsExist(request.ID))
        {
            throw new CqrsException(Errors.TASK_NOT_FOUND);
        }

        var task = await this.tasksRepository.LoadTask(request.ID);

        task.UpdateState(request.State);
        task.UpdateCurrentDateTime();

        await this.tasksRepository.SaveTask(task);
    }
}