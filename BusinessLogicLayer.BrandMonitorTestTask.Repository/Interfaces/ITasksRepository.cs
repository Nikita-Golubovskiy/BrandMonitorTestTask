using System;
using System.Threading.Tasks;

using TaskModel = BusinessLogicLayer.BrandMonitorTestTask.Model.Task;
using GetTaskInformationData = BusinessLogicLayer.BrandMonitorTestTask.Repository.ParameterObjects.ITasksRepository.GetTaskInformation.TaskData;

// ReSharper disable UnusedMember.Global

namespace BusinessLogicLayer.BrandMonitorTestTask.Repository.Interfaces;

/// <summary>
/// Tasks repository model interface.
/// </summary>
public interface ITasksRepository
{
    /// <summary>
    /// Task existence checking by <paramref name="id" /> method.
    /// </summary>
    /// <param name="id">Task ID value.</param>
    /// <returns>True, if task with specified <paramref name="id" /> exists. Otherwise, returns false.</returns>
    Task<bool> IsExist(Guid id);

    /// <summary>
    /// Task DDD model with child models by task <paramref name="id" /> loading method.
    /// </summary>
    /// <param name="id">Task ID, which one must be loaded.</param>
    /// <returns>Loaded task DDD model.</returns>
    Task<TaskModel> LoadTask(Guid id);

    /// <summary>
    /// Task DDD model from <paramref name="model" /> with child models saving method.
    /// </summary>
    /// <param name="model">Task DDD model, which one must be saved.</param>
    /// <returns>Result descriptor.</returns>
    Task SaveTask(TaskModel model);

    /// <summary>
    /// Information for <paramref name="taskID" />-matched task obtaining method.
    /// </summary>
    /// <param name="taskID">Task ID value.</param>
    /// <returns>
    /// Information-containing response for <paramref name="taskID" />-matched task.
    /// </returns>
    Task<GetTaskInformationData> GetTaskInformation(Guid taskID);
}