using SharedLayer.BrandMonitorTestTask.Interfaces;

using EntityObject = DataAccessLayer.BrandMonitorTestTask.Database.Entities.Task;
using ParameterObject = BusinessLogicLayer.BrandMonitorTestTask.Repository.ParameterObjects.ITasksRepository.GetTaskInformation.TaskData;

namespace DataAccessLayer.BrandMonitorTestTask.Repository.Converters.Tasks.GetTaskInformation;

/// <summary>
/// <see cref="EntityObject">EntityObject</see> repository parameter objects to <see cref="ParameterObject">ParameterObject</see> object converter.
/// </summary>
internal sealed class Converter : IDirectConverter<EntityObject, ParameterObject>
{
    /// <summary>
    /// Value conversion method.
    /// </summary>
    /// <param name="source">Source value to convert.</param>
    /// <returns>Result/converted value.</returns>
    public ParameterObject Convert(EntityObject source)
    {
        if (source is null)
        {
            return null;
        }
        var result = new ParameterObject(
            // ReSharper disable once PossibleInvalidOperationException
            source.ID.Value,
            source.State
        );

        return result;
    }
}