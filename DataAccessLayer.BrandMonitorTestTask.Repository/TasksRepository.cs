using System;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.BrandMonitorTestTask.Repository.Interfaces;
using DataAccessLayer.BrandMonitorTestTask.Database.Contexts;
using Microsoft.EntityFrameworkCore;

using TaskEntity = DataAccessLayer.BrandMonitorTestTask.Database.Entities.Task;
using TaskModel = BusinessLogicLayer.BrandMonitorTestTask.Model.Task;
using GetTaskInformationData = BusinessLogicLayer.BrandMonitorTestTask.Repository.ParameterObjects.ITasksRepository.GetTaskInformation.TaskData;

namespace DataAccessLayer.BrandMonitorTestTask.Repository;

/// <summary>
/// Tasks repository implementation class.
/// </summary>
public sealed class TasksRepository : ITasksRepository
{

    /// <summary>
    /// Task existence checking by <paramref name="id" /> method.
    /// </summary>
    /// <param name="id">Task ID value.</param>
    /// <returns>True, if task with specified <paramref name="id" /> exists. Otherwise, returns false.</returns>
    public async Task<bool> IsExist(Guid id)
    {
        await using var brandMonitorTestTaskContext = new BrandMonitorTestTaskContext();

        var result = await brandMonitorTestTaskContext
            .Tasks
            .AsNoTracking()
            .AnyAsync(task => task.ID == id);

        return result;
    }

    /// <summary>
    /// Task DDD model with child models by task <paramref name="id" /> loading method.
    /// </summary>
    /// <param name="id">Task ID, which one must be loaded.</param>
    /// <returns>Loaded task DDD model.</returns>
    public async Task<TaskModel> LoadTask(Guid id)
    {
        await using var brandMonitorTestTaskContext = new BrandMonitorTestTaskContext();

        var resultTask = await brandMonitorTestTaskContext
            .Tasks
            .AsNoTracking()
            .SingleAsync(task => task.ID == id);

        var converter = new Converters.Tasks.LoadTask.Converter();

        return converter.Convert(resultTask);
    }

    /// <summary>
    /// Task DDD model from <paramref name="model" /> with child models saving method.
    /// </summary>
    /// <param name="model">Task DDD model, which one must be saved.</param>
    /// <returns>Result descriptor.</returns>
    public async Task SaveTask(TaskModel model)
    {
        await using var brandMonitorTestTaskContext = new BrandMonitorTestTaskContext();

        var isExists = await this.IsExist(model.ID);

        var taskEntity = await brandMonitorTestTaskContext
            .Tasks
            .SingleOrDefaultAsync(task => task.ID == model.ID);

        taskEntity ??= new TaskEntity
        {
            ID = model.ID
        };

        taskEntity.State = model.State;
        taskEntity.CurrentDateTime = model.CurrentDateTime;

        if (isExists)
        {
            brandMonitorTestTaskContext.Update(taskEntity);
        }
        else
        {
            brandMonitorTestTaskContext.Add(taskEntity);
        }

        await brandMonitorTestTaskContext
            .SaveChangesAsync()
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Information for <paramref name="taskID" />-matched task obtaining method.
    /// </summary>
    /// <param name="taskID">Task ID value.</param>
    /// <returns>
    /// Information-containing response for <paramref name="taskID" />-matched task.
    /// </returns>
    public async Task<GetTaskInformationData> GetTaskInformation(Guid taskID)
    {
        await using var brandMonitorTestTaskContext = new BrandMonitorTestTaskContext();

        var resultTask = await brandMonitorTestTaskContext
            .Tasks
            .AsNoTracking()
            .Where(task => task.ID == taskID)
            .SingleAsync();

        var converter = new Converters.Tasks.GetTaskInformation.Converter();

        return converter.Convert(resultTask);
    }
}