using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using GetTaskInformationQueryResponse = PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.GetTaskInformation.Response;

// ReSharper disable UnusedMember.Global

namespace PresentationLayer.BrandMonitorTestTask.Rest.V1.Interfaces;

/// <summary>
/// Tasks controller interface.
/// </summary>
public interface ITasksController
{
    /// <summary>
    /// Run new task processing method.
    /// </summary>
    /// <returns>New task ID value.</returns>
    ActionResult<Guid> RunTask();

    /// <summary>
    /// Get task information, matching <paramref name="taskID" /> value obtaining method.
    /// </summary>
    /// <param name="taskID">Task ID value.</param>
    /// <returns>Task information data response value.</returns>
    Task<ActionResult<GetTaskInformationQueryResponse>> GetTaskInformation(string taskID);
}