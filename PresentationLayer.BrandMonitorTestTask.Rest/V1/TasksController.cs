using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.BrandMonitorTestTask.Rest.V1.Interfaces;
using PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Command.Canonical;
using System.ComponentModel.DataAnnotations;
using PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Query.Parametric;

using CreateTaskCommandRequest = PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.CreateTask.Request;

using UpdateStateCommandRequest = PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.UpdateState.Request;

using GetTaskInformationQueryRequest = PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.GetTaskInformation.Request;
using GetTaskInformationQueryResponse = PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.GetTaskInformation.Response;

// ReSharper disable NotAccessedField.Local

namespace PresentationLayer.BrandMonitorTestTask.Rest.V1;

/// <summary>
/// Tasks controller class.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}")]
public sealed class TasksController : ControllerBase, ITasksController
{
    /// <summary>
    /// New task creating command DI reference field.
    /// </summary>
    private readonly IAsyncCommand<CreateTaskCommandRequest> createTaskCommand;

    /// <summary>
    /// Existing task state update command DI reference field.
    /// </summary>
    private readonly IAsyncCommand<UpdateStateCommandRequest> updateStateCommand;

    /// <summary>
    /// Task information obtaining query DI reference field.
    /// </summary>
    private readonly IAsyncQuery<GetTaskInformationQueryRequest, GetTaskInformationQueryResponse> getTaskInformationCommand;

    /// <summary>
    /// Main constructor.
    /// </summary>
    /// <param name="createTaskCommand">New task creating command reference value, obtaining from DI.</param>
    /// <param name="updateStateCommand">Existing task state update command reference value, obtaining from DI.</param>
    /// <param name="getTaskInformationCommand">Task information obtaining query reference value, obtaining from DI.</param>
    public TasksController(
        IAsyncCommand<CreateTaskCommandRequest> createTaskCommand,
        IAsyncCommand<UpdateStateCommandRequest> updateStateCommand,
        IAsyncQuery<GetTaskInformationQueryRequest, GetTaskInformationQueryResponse> getTaskInformationCommand
    ) {
        this.createTaskCommand = createTaskCommand;
        this.updateStateCommand = updateStateCommand;
        this.getTaskInformationCommand = getTaskInformationCommand;
    }

    /// <summary>
    /// Run new task processing method.
    /// </summary>
    /// <returns>New task ID value.</returns>
    [HttpPost]
    [Route("task")]
    public ActionResult<Guid> RunTask()
    {
        const string taskRunningState = "running";
        const string taskFinishedState = "finished";

        var newTaskID = Guid.NewGuid();

        var createTaskCommandRequest = new CreateTaskCommandRequest(newTaskID);

        var updateStateToRunCommandRequest = new UpdateStateCommandRequest(
            newTaskID,
            taskRunningState
        );

        var updateStateToFinishCommandRequest = new UpdateStateCommandRequest(
            newTaskID,
            taskFinishedState
        );

        var delayTime = new TimeSpan(0, 0, 2, 0);

        this.createTaskCommand.Execute(createTaskCommandRequest)
            .ContinueWith( async _ =>
                await this.updateStateCommand.Execute(updateStateToRunCommandRequest)
                    .ContinueWith(async _ =>
                        await Task.Delay(delayTime)
                            .ContinueWith(async _ => await this.updateStateCommand.Execute(updateStateToFinishCommandRequest))
                    )
            );

        return this.Accepted(newTaskID);
    }

    /// <summary>
    /// Get task information, matching <paramref name="taskID" /> value obtaining method.
    /// </summary>
    /// <param name="taskID">Task ID value.</param>
    /// <returns>Task information data response value.</returns>
    [HttpGet]
    [Route("task/{taskID}")]
    public async Task<ActionResult<GetTaskInformationQueryResponse>> GetTaskInformation(
        [Required] string taskID
    ) {
        if (!Guid.TryParse(taskID, out var taskIDToGuid))
        {
            return this.BadRequest();
        }

        var queryRequest = new GetTaskInformationQueryRequest(taskIDToGuid);

        var result = await this.getTaskInformationCommand.Execute(queryRequest);

        if (!result.TaskIsExists)
        {
            return this.NotFound();
        }

        return result;
    }
}