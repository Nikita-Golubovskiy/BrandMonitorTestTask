using System;
using System.Threading.Tasks;
using BusinessLogicLayer.BrandMonitorTestTask.Repository.Interfaces;
using PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.CreateTask;
using PresentationLayer.BrandMonitorTestTask.Cqrs.Exceptions;
using PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Command.Canonical;

using TaskModel = BusinessLogicLayer.BrandMonitorTestTask.Model.Task;

using Errors = PresentationLayer.BrandMonitorTestTask.Cqrs.Assets.Strings.Errors.Common;

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.Commands;

/// <summary>
/// New task creating command class.
/// </summary>
public sealed class CreateTask : IAsyncCommand<Request>
{
    /// <summary>
    /// Tasks repository DI reference field.
    /// </summary>
    private readonly ITasksRepository tasksRepository;

    /// <summary>
    /// Main constructor.
    /// </summary>
    /// <param name="tasksRepository">Tasks repository reference value, obtaining from DI.</param>
    public CreateTask(ITasksRepository tasksRepository)
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
        const string createdTaskState = "created";

        if (request is null)
        {
            throw new CqrsException(Errors.REQUEST_ARGUMENT_IS_MISSING);
        }

        if (await this.tasksRepository.IsExist(request.ID))
        {
            throw new CqrsException(Errors.TASK_ID_ALREADY_IN_USE);
        }

        var task = new TaskModel(
            request.ID,
            createdTaskState,
            DateTime.Now
        );

        await this.tasksRepository.SaveTask(task);
    }
}