using SharedLayer.BrandMonitorTestTask.Interfaces;

using ParameterObject = BusinessLogicLayer.BrandMonitorTestTask.Repository.ParameterObjects.ITasksRepository.GetTaskInformation.TaskData;
using DataTransferObject = PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.GetTaskInformation.Response;

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.Converters.GetTaskInformation;

/// <summary>
/// <see cref="ParameterObject">ParameterObject</see> repository parameter objects to <see cref="DataTransferObject">DataTransferObject</see> object converter.
/// </summary>
internal sealed class Converter : IDirectConverter<ParameterObject, DataTransferObject>
{
    /// <summary>
    /// Value conversion method.
    /// </summary>
    /// <param name="source">Source value to convert.</param>
    /// <returns>Result/converted value.</returns>
    public DataTransferObject Convert(ParameterObject source)
    {
        if (source is null)
        {
            return null;
        }

        var result = new DataTransferObject(
            source.ID.ToString(),
            source.State,
            true
        );

        return result;
    }
}